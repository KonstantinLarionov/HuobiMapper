using HuobiMapper.USDTFutures.RestApi.Data.Account.CancealanOrder;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class CancelanOrderResponses
    {
        [JsonConstructor]
        public CancelanOrderResponses(CancelanOrderdata data, string status, long ts)
        {
            Data = data;
            Status = status;
            Ts = ts;
        }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public CancelanOrderdata Data { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}