using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceaBatchofOrders;
using HuobiMapper.USDTFutures.RestApi.Data.Account.PlaceOrderData;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class PlaceaBatchofOrderResponses
    {
        [JsonConstructor]
        public PlaceaBatchofOrderResponses(DataPBO data, string status, long ts)
        {
            Status = status;
            Ts = ts;
            DataPBOs = data;
        }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("data")]
        public DataPBO DataPBOs { get; set; }
    }
}