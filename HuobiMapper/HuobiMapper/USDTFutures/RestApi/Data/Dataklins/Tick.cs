using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.RestApi.Data.Dataklins
{
    public class Tick
    {
        [JsonConstructor]
        public Tick(decimal amount, decimal close, decimal count, decimal high, long id, decimal low, decimal open, decimal tradeturnover, decimal vol)

        {
            Amount = amount;
            Close = close;
            Count = count;
            High = high;
            Id = id;
            Low = low;
            Open = open;
            Tradeturnover = tradeturnover;
            Vol = vol;

        }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("close")]
        public decimal Close { get; set; }
        [JsonProperty("count")]
        public decimal Count { get; set; }
        [JsonProperty("high")]
        public decimal High { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("low")]
        public decimal Low { get; set; }
        [JsonProperty("open")]
        public decimal Open { get; set; }
        [JsonProperty("trade_turnover")]
        public decimal Tradeturnover { get; set; }
        [JsonProperty("vol")]
        public decimal Vol { get; set; }
    }
}