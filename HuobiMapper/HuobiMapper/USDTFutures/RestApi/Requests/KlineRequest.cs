using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using JetBrains.Annotations;
namespace HuobiMapper.USDTFutures.RestApi.Requests
{
    public class KlineRequest : RequestPayload

    {
        public KlineRequest(string contractcode, Period period)
        {
            Contractcode = contractcode;
            Period = period;
        }

        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public int Size { get; set; } = 150;
        public Period Period { get; set; }
        public string Contractcode { get; set; }

        private long FromLong
        {
            get { return From.ToUnixTimeSeconds(); }
        }

        private long ToLong
        {
            get { return To.ToUnixTimeSeconds(); }
        }

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var def = new Dictionary<string, string>();
                def.AddEnum("period", Period);
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code", Contractcode);
                def.AddSimpleStruct("from", FromLong);
                def.AddSimpleStruct("to", ToLong);
                def.AddSimpleStruct("size", Size);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-ex/market/history/kline";
        internal override RequestMethod Method { get; } = RequestMethod.GET;
    }
}