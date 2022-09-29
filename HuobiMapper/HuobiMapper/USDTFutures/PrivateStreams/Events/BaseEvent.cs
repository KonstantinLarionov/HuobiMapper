using System.Runtime.Serialization;
using HuobiMapper.USDTFutures.PrivateStreams.Data.Enums;
using JetBrains.Annotations;
using Newtonsoft.Json;
using HuobiMapper.Extensions;
namespace HuobiMapper.USDTFutures.PrivateStreams.Events
{
    public class BaseEvent
    {
        [JsonProperty("error")]
        public ErrorEvent Error { get; set; }

        [JsonProperty("accounts")] [CanBeNull] public object Accounts { get; set; }
        [JsonProperty("orders")] [CanBeNull] public object Orders { get; set; }
        [JsonProperty("positions")] [CanBeNull] public object Positions { get; set; }

        public EventType EventType {
            get
            {
                if (Accounts is null && Orders is null && Positions is null &&
                    this.Result != null && this.Result.StatusEnum is StatusBaseEvent.Success)
                    return Data.Enums.EventType.UserLogin;
                if (Accounts != null || Orders != null || Positions != null)
                    return Data.Enums.EventType.AccountOrderPosition;
                return EventType.None;
            }
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("result")]
        public ResultEvent Result { get; set; }
    }

    public class ErrorEvent
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class ResultEvent
    {
        [JsonConstructor]
        public ResultEvent(string status)
        {
            Status = status;
            StatusEnum = Status.ToEnum<StatusBaseEvent>();
        }

        [JsonProperty("status")]
        public string Status { get; set; }
        public StatusBaseEvent StatusEnum { get; set; }
    }

    public enum StatusBaseEvent
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "error")]
        Error,
    }
}