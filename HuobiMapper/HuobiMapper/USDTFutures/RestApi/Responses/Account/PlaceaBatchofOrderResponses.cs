using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class PlaceaBatchofOrderResponses
    {
        [JsonConstructor]
        public PlaceaBatchofOrderResponses(List<PlaceOrderRow> placeOrderRows, string status, long ts)
        {
            Status = status;
            Ts = ts;
            DataplaceOrderRows = placeOrderRows;
        }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("placeOrderRows")]
        public List<PlaceOrderRow> DataplaceOrderRows { get; set; }
    }
}