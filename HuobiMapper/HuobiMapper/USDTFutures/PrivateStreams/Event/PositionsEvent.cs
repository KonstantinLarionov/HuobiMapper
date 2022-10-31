using System.Collections.Generic;
using Huobi.SDK.Core.WSBase.PrivateStreams.Data.PositionsSubs;
using Huobi.SDK.Core.WSBase.PrivateStreams.Enums;
using HuobiMapper.Extensions;
using Newtonsoft.Json;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Event
{
    public class PositionsEvent
    {
        [JsonProperty("op")]
        public string Op { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
        public EventType EventType {
            get
            {
                return Event.ToEnum<EventType>();
            }
        }

        [JsonProperty("data")]
        public List<PositionData> Data { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }
    }
}