using System.Collections.Generic;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Data
{
    public class Ticks
    {   [JsonConstructor]
        public Ticks(List<List<decimal>> asks, List<List<decimal>> bids, string ch, string @event, long id, long mrid, long ts, long version)
        {
            Asks = asks;
            Bids = bids;
            Ch = ch;
            Event = @event;
            Id = id;
            Mrid = mrid;
            Ts = ts;
            Version = version;
        }
        [JsonProperty("asks")]
        public List<List<decimal>> Asks { get; set; }

        [JsonProperty("bids")]
        public List<List<decimal>> Bids { get; set; }

        [JsonProperty("ch")]
        public string Ch { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

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