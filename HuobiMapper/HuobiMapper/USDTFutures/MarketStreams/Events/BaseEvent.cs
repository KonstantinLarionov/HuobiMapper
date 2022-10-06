﻿using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using HuobiMapper.USDTFutures.RestApi.Data.Dataklins;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Events
{
    public class BaseEvent
    {
        [JsonProperty("ch")]
        public string Ch { get; set; }

        [JsonProperty("trades")]
        [CanBeNull] public object Trade { get; set; }
        [JsonProperty("depth")]
        [CanBeNull] public object Depth { get; set; }

        public EventType EventType {
            get
            {
                if (Trade != null)
                    return EventType.Trade;
                if (Depth != null)
                    return EventType.Depth;
                return EventType.None;
            }
        }

        [JsonProperty("tick")]
        public Tick Tick { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}