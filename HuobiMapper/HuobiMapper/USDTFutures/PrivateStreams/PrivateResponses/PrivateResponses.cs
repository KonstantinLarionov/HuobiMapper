using System.Collections.Generic;
using HuobiMapper.USDTFutures.PrivateStreams.Data;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.PrivateStreams.PrivateResponses
{
    public class PrivateResponses
    {
        [JsonConstructor]
        public PrivateResponses(string status,long ts, List<AccountData> data)
        {
            Status = status;
            Ts = ts;
            AccountData = data;
        }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("ts")]
        public long Ts { get; set; }
        
        [JsonProperty("data")]
        public List<AccountData> AccountData { get; set; }
    }
}