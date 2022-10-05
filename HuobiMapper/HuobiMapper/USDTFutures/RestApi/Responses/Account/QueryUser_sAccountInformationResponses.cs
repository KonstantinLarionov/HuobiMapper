using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.Account.QueryUser_sAccountInformation;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class QueryUserSAccountInformationResponses
    {   [JsonConstructor]
        public QueryUserSAccountInformationResponses(string status, List<QueryUserSAccountInformation> data, long ts)
        {
            Status = status;
            Data = data;
            Ts = ts;
        }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public List<QueryUserSAccountInformation> Data { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}