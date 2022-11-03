using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.Account.TradeHistory;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class TradesResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        
        [JsonProperty("err_msg")]
        public string ErrMsg { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public List<TradeData> Data { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}