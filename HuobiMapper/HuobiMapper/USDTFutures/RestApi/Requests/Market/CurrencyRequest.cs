using System;
using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Market
{
    public class CurrencyRequest : RequestPayload
    {
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public string Contractcode { get; set; }
        public string Supportmarginmode { get; set; }
        public string Pair { get; set; }
        public string Contracttype { get; set; }
        public string Businesstype { get; set; }
        
        private long FromLong
        {
            get { return From.ToUnixTimeSeconds(); }
        }

        private long ToLong
        {
            get { return To.ToUnixTimeSeconds(); }
        }
        
        internal override Dictionary<string, string> Properties
        {
            get
            {
                var def = new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("support_margin_mode", Supportmarginmode);
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code", Contractcode);
                def.AddSimpleStruct("from", FromLong);
                def.AddSimpleStruct("to", ToLong);
                def.AddStringIfNotEmptyOrWhiteSpace("pair", Pair);
                def.AddStringIfNotEmptyOrWhiteSpace("contract_type", Contracttype);
                def.AddStringIfNotEmptyOrWhiteSpace("business_type", Businesstype);
                return def;
            }
        }
        
    [NotNull]internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_contract_info";
    internal override RequestMethod Method { get; } = RequestMethod.GET;
    }
}