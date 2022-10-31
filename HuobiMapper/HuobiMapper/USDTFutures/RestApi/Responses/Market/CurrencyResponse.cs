using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using HuobiMapper.USDTFutures.RestApi.Extensions;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Market
{
    public class CurrencyResponse
    {
        [JsonConstructor]
        public CurrencyResponse(long ts, string status, List<CurrencysData> data)
        {
            Ts = ts;
            Status = status;
            Data = data;
            StatusType = Status.ToEnum<StatusRequest>();
        }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public StatusRequest StatusType { get; set; }

        [JsonProperty("data")]
        public List<CurrencysData> Data { get; set; }
    } 
    
}