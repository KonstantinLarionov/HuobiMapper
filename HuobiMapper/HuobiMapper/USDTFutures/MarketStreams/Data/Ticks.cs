using System.Collections.Generic;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using HuobiMapper.USDTFutures.RestApi.Extensions;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Data
{
    public class Ticks
    {   [JsonConstructor]
        public Ticks(List<OrderDepthRow> asks, List<OrderDepthRow> bids, string ch, string @event, long id, long mrid, long ts, long version)
        {
            Asks = asks;
            Bids = bids;
            Ch = ch;
            Event = @event;
            Id = id;
            Mrid = mrid;
            Ts = ts;
            Version = version;
            EventDataType = Event.ToEnum<EventDataType>();
        }
        [JsonProperty("asks")]
        public List<OrderDepthRow> Asks { get; set; }

        [JsonProperty("bids")]
        public List<OrderDepthRow> Bids { get; set; }

        [JsonProperty("ch")]
        public string Ch { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
        public EventDataType EventDataType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("mrid")]
        public long Mrid { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }
    }
}