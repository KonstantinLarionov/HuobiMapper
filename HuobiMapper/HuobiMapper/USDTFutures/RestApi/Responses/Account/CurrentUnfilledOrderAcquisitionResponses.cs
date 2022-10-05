using HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class CurrentUnfilledOrderAcquisitionResponses
    {
        public CurrentUnfilledOrderAcquisitionResponses(string status, CurrentUnfilledOrderAcquisition data, long ts)
        {
            Status = status;
            Data = data;
            Ts = ts;
        }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public CurrentUnfilledOrderAcquisition Data { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}