using System.Collections.Generic;
using HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class GetHistoryOrdersResponses
    {
        public GetHistoryOrdersResponses(int code, string msg, List<GetHistoryOrders> data, long ts)
        {
            Code = code;
            Msg = msg;
            Data = data;
            Ts = ts;
        }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("data")]
        public List<GetHistoryOrders> Data { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}