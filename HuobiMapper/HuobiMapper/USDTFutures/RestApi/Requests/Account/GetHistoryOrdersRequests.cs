using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class GetHistoryOrdersRequests:KeyedRequestPayload
    {
        public GetHistoryOrdersRequests(string contract, int tradetype, string status, int type)
        {
            Contract = contract;
            Tradetype = tradetype;
            Status = status;
            Type = type;
        }
        public string Contract { get; set; }
        public int Tradetype { get; set; } = 0;
        public string Status { get; set; }
        public int Type { get; set; } = 1;
        public long? Starttime { get; set; }
        public long? Endtime { get; set; }
        public string Direct { get; set; }
        public long? Fromid { get; set; }
        internal override Dictionary<string, string> Properties
        {
            get
            {
                var def= new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract", Contract);
                def.AddStringIfNotEmptyOrWhiteSpace("status", Status);
                def.AddStringIfNotEmptyOrWhiteSpace("direct", Direct);
                def.AddSimpleStruct("trade_type", Tradetype);
                def.AddSimpleStruct("trade_type", Type);
                def.AddSimpleStructIfNotNull("start_time", Starttime);
                def.AddSimpleStructIfNotNull("end_time", Endtime);
                def.AddSimpleStructIfNotNull("from_id", Fromid);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v3/swap_hisorders";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
    }
}