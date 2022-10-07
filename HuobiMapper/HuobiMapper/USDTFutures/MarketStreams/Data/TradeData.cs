using System.Collections.Generic;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Data
{
    public class data
    {   [JsonConstructor]
        public data(decimal amount, long ts, long id, decimal price, string direction, decimal quantity,decimal tradeturnover)
        {
            Amount = amount;
            Ts = ts;
            Id = id;
            Price = price;
            Direction = direction;
            Quantity = quantity;
            Tradeturnover = tradeturnover;
        }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("Quantity")]
        public decimal Tradeturnover { get; set; }
    }

    public class tick
    {
        [JsonConstructor]
        public tick(long id, long ts, List<data> data)
        {
            Id = id;
            Ts = ts;
            Data = data;
        }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("data")]
        public List<data> Data { get; set; }
    }

    public class OrderTradeEvent
    {
        [JsonConstructor]
        public OrderTradeEvent(string ch, long ts, tick tick)
        {
            Ch = ch;
            Ts = ts;
            Tick = tick;
        }
        [JsonProperty("ch")]
        public string Ch { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("tick")]
        public tick Tick { get; set; }
    }
}