using HuobiMapper.USDTFutures.MarketStreams.Data;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Events
{
    public class TradeEvent
    {
        [JsonConstructor]
        public TradeEvent(string ch, long ts, TradeTick tradeTick)
        {
            Ch = ch;
            Ts = ts;
            TradeTick = tradeTick;
        }
        [JsonProperty("ch")]
        public string Ch { get; set; }
        public string Symbol {
            get
            {
                var str = Ch?.Split('.');
                return str?[1];
            }
        }

        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("tick")]
        public TradeTick TradeTick { get; set; }
    }
}