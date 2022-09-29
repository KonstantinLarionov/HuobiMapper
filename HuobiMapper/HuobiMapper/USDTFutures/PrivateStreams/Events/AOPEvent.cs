using System.Collections.Generic;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.PrivateStreams.Data;
using HuobiMapper.USDTFutures.PrivateStreams.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.PrivateStreams.Events
{
    public class AOPEvent : BaseEvent
    {
        [JsonConstructor]
        public AOPEvent(int sequence, long timestamp, string type, int version, List<AccountData> accounts)
        {
            Sequence = sequence;
            Timestamp = timestamp;
            Type = type;
            TypeEnum = Type.ToEnum<EventType>();
            Version = version;
            Accounts = accounts;
           ;
        }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
        public EventType TypeEnum { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("accounts")]
        public List<AccountData> Accounts { get; set; }
    }
}