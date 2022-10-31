using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition;
using HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class CurrentUnfilledOrderAcquisitionRequests:KeyedRequestPayload
    {
        public CurrentUnfilledOrderAcquisitionRequests(string contractcode)
        {
            Contractcode = contractcode;
        }
        public string Contractcode { get; set; }
        public int Pageindex { get; set; } = 1;
        public int Pagesize { get; set; } = 20;
        public SortedBy? SortedBy { get; set; }
        public TradeType Tradetype { get; set; } = 0;

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
                var def = new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code",Contractcode);
                def.AddEnumIfNotNull("sort_by",SortedBy);
                def.AddSimpleStruct("page_index",Pageindex);
                def.AddSimpleStruct("page_size",Pagesize);
                def.AddSimpleStruct("trade_type", (int)Tradetype);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_openorders";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
    }   
}