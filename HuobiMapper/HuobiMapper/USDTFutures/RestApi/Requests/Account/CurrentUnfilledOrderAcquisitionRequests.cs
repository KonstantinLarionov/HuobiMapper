using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
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
        public string Sortby { get; set; }
        public int Tradetype { get; set; } = 0;

        internal override Dictionary<string, string> Properties
        {
            get
            {
                var def = new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code",Contractcode);
                def.AddStringIfNotEmptyOrWhiteSpace("sort_by",Sortby);
                def.AddSimpleStruct("page_index",Pageindex);
                def.AddSimpleStruct("page_size",Pagesize);
                def.AddSimpleStruct("trade_type",Tradetype);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_openorders";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
    }   
}