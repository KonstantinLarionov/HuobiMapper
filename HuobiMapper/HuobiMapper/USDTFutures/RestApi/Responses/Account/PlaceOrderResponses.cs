using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class PlaceOrderResponses
    {
        [JsonConstructor]
        public PlaceOrderResponses(string status, PlaceOrder data, long ts)
        {
            Status = status;
            Ts = ts;
            PlOrData = data;
        }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("data")]
        public PlaceOrder PlOrData { get; set; }
    }
}