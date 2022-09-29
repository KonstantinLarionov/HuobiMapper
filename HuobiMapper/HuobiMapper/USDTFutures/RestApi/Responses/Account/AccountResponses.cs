using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.AccountInfo;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class AccountResponses
    {
        [JsonConstructor]
        public AccountResponses(string status,long ts, List<AccountData> data)
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