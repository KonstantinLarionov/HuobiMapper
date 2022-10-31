using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Data.Dataklins;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Market
{
    public class DataKlineResponse
    {
        [JsonConstructor]
        public DataKlineResponse(List<Tick> tick, string ch, long ts, string status)
        {
            Tick = tick;
            Ch = ch;
            Ts = ts;
            Status = status;
            StatusType = Status.ToEnum<StatusRequest>();
        }
        [JsonProperty("data")]
        public List<Tick> Tick { get; set; }
        [JsonProperty("ch")]
        public string Ch { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        public StatusRequest StatusType { get; set; }

    }

    
    
}