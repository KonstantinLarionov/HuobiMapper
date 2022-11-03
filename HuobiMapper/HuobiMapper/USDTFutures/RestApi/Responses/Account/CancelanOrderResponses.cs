using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Data.Account.CancealanOrder;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class CancelanOrderResponses
    {
        [JsonConstructor]
        public CancelanOrderResponses(CancelanOrderdata data, string erroMsg, string status, long ts)
        {
            Data = data;
            Status = status;
            Ts = ts;
            ErrMsg = erroMsg;
        }
        [JsonProperty("status")]
        public string Status { get; set; }  
        [JsonProperty("err_msg")]
        public string ErrMsg { get; set; }
        public StatusRequest StatusType
        {
            get { return Status.ToEnum<StatusRequest>(); }
        }

        [JsonProperty("data")]
        public CancelanOrderdata Data { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}