using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class PlaceOrderResponses
    {
        [JsonConstructor]
        public PlaceOrderResponses(string status, string errmsg, PlaceOrder data, long ts)
        {
            Status = status;
            Ts = ts;
            PlOrData = data;
            ErrMsg = errmsg;
        }
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("err_msg")]
        public string ErrMsg { get; set; }
        public StatusRequest StatusType
        {
            get { return Status.ToEnum<StatusRequest>(); }
        }

        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("data")]
        public PlaceOrder PlOrData { get; set; }
    }
}