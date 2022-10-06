using HuobiMapper.USDTFutures.RestApi.Data.Dataklins;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Data
{
    public class SubIncrementalhData
    {
        [JsonConstructor]
        public SubIncrementalhData(string ch, Tick tick, long ts)
        {
            Ch = ch;
            Tick = tick;
            Ts = ts;
        }
        [JsonProperty("ch")]
        public string Ch { get; set; }

        [JsonProperty("tick")]
        public Tick Tick { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }
    }
}