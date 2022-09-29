using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses
{
    public class CurrencyResponse
    {
        [JsonConstructor]
        public CurrencyResponse(long ts, string status, List<CurrencysData> data)
        {
            Ts = ts;
            Status = status;
            Data = data;
        }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<CurrencysData> Data { get; set; }
    } 
    
}