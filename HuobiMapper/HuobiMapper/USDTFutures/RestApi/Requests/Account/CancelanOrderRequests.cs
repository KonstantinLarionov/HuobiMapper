using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class CancelanOrderRequests:KeyedRequestPayload
    {
        public CancelanOrderRequests(string contractcode)
        {
            Contractcode = contractcode;
        }
        public string Orderid { get; set; }
        public string Clientorderid { get; set; }
        public string Contractcode { get; set; }
        
        public override Dictionary<string, string> Properties
        {
            get
            {
                var def = new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code", Contractcode);
                def.AddStringIfNotEmptyOrWhiteSpace("order_id", Orderid);
                def.AddStringIfNotEmptyOrWhiteSpace("client_order_id", Clientorderid);
                return def;
            }
        }
        [NotNull] internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_cancel";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
    }
}