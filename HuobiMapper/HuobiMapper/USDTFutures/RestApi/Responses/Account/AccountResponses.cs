using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Data.Account.AccountInfo;
using HuobiMapper.USDTFutures.RestApi.Data.Account.AccountInfo;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class AccountResponses
    {
        [JsonConstructor]
        public AccountResponses(string status, string errMsg, long ts, List<AccountData> data)
        {
            Status = status;
            Ts = ts;
            AccountData = data;
            ErrMsg = errMsg;
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
        public List<AccountData> AccountData { get; set; }
    }
}