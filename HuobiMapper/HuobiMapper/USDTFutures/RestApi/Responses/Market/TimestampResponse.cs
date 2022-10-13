using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Market
{
    public class TimestampResponse
    {
        [JsonConstructor]
        public TimestampResponse(string status, long timestamp)
        {
            Status = status;
            Timestamp = timestamp;
            ResponseStatus = Status.ToEnum<ResponseStatus>();
        }

        [JsonProperty("status")]
        public string Status { get; set; }
        public ResponseStatus ResponseStatus { get; set; }

        [JsonProperty("ts")]
        public long Timestamp { get; set; }
    }
}