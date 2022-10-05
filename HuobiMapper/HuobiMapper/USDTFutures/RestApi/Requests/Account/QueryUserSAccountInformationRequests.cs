using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;

namespace HuobiMapper.USDTFutures.RestApi.Requests.Account
{
    public class QueryUserSAccountInformationRequests: KeyedRequestPayload
    {
        public string Contractcode { get; set; }

        internal override Dictionary<string, string> Properties
        {
            get
            {   
                var def = new Dictionary<string, string>();
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code", Contractcode);
                
                return def;
            }
        } 
        internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_position_info";
        internal override RequestMethod Method { get; } = RequestMethod.POST;
    }
}