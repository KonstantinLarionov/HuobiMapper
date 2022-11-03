using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition;
using HuobiMapper.USDTFutures.RestApi.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Responses.Account
{
    public class CurrentUnfilledOrderAcquisitionResponses
    {
        public CurrentUnfilledOrderAcquisitionResponses(string status, string errMsg, CurrentUnfilledOrderAcquisition data, long ts)
        {
            Status = status;
            Data = data;
            Ts = ts;
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

        [JsonProperty("data")]
        public CurrentUnfilledOrderAcquisition Data { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}