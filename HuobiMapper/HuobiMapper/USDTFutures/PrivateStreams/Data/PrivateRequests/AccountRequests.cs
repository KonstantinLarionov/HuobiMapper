using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using HuobiMapper.Extensions;
using HuobiMapper.Requests.Output;
using HuobiMapper.Requests.Payload;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.PrivateRequests
{
    public class AccountRequests : KeyedRequestPayload

    {
       
        
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public string Contractcode { get; set; }
        /*public string apiKey { get; set; }
        public string Orderid { get; set; }
        public string SignatureMethod { get; set; }
        public string SignatureVersion { get; set; }
        public string Timestamp { get; set; }*/
       
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
                def.AddSimpleStruct("from", FromLong);
                def.AddSimpleStruct("to", ToLong);
                def.AddStringIfNotEmptyOrWhiteSpace("contract_code",Contractcode);
                /*def.AddStringIfNotEmptyOrWhiteSpace("AccessKeyId",apiKey);
                def.AddStringIfNotEmptyOrWhiteSpace("order-id", Orderid);
                def.AddStringIfNotEmptyOrWhiteSpace("SignatureMethod", SignatureMethod);
                def.AddStringIfNotEmptyOrWhiteSpace("SignatureVersion", SignatureVersion);
                def.AddStringIfNotEmptyOrWhiteSpace("Timestamp", Timestamp);*/
                
                return def;
            }
        } 
        [NotNull]internal override string EndPoint { get; } = "/linear-swap-api/v1/swap_account_info";
                 internal override RequestMethod Method { get; } = RequestMethod.POST;
    }
}