using System;
using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class GetHistoryOrdersRequests : KeyedRequestPayload
    {
        public GetHistoryOrdersRequests(string contract, TradeType tradetype, OrderStatusEnum status, OrderType type)
        {
            Contract = contract;
            Tradetype = (int)tradetype;
            // Status = string.Join(",",
            //     Array.ConvertAll(status, value => (int)value));
            Status = (int)status;
            Type = (int)type;
        }

        public string Contract { get; set; }
        public int Tradetype { get; set; } = 0;
        public int Status { get; set; }
        public int Type { get; set; } = 1;
        public long? Starttime { get; set; }
        public long? Endtime { get; set; }
        public string Direct { get; set; }
        public long? Fromid { get; set; }
        public override object Body {
            get
            {
                return Properties.FromDictToAnonymousObj();
            }
        }

        public override  Dictionary<string, string> Properties
        {
            get
            {
                var def= new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract", Contract);
                def.AddSimpleStruct("status", Status);
                def.AddStringIfNotEmptyOrWhiteSpace("direct", Direct);
                def.AddSimpleStruct("trade_type", Tradetype);
                def.AddSimpleStruct("type", Type);
                def.AddSimpleStructIfNotNull("start_time", Starttime);
                def.AddSimpleStructIfNotNull("end_time", Endtime);
                def.AddSimpleStructIfNotNull("from_id", Fromid);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v3/swap_hisorders";
        internal override RequestMethod Method { get; } = RequestMethod.POST;

        public class Payload
        {
            public string contract { get; set; }
            public int trade_type { get; set; }
            public string status { get; set; }
            public int type { get; set; }
            public long start_time { get; set; }
            public long end_time { get; set; }
            public string direct { get; set; }
            public int from_id { get; set; }
        }
    }
}