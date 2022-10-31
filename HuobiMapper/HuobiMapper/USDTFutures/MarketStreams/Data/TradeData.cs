using System.Collections.Generic;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using HuobiMapper.USDTFutures.RestApi.Extensions;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Data
{
    public class TradeData
    {   [JsonConstructor]
        public TradeData(decimal amount, long ts, long id, decimal price, string direction, decimal quantity,decimal tradeturnover)
        {
            Amount = amount;
            Ts = ts;
            Id = id;
            Price = price;
            Direction = direction;
            DirectionType = Direction.ToEnum<DirectionType>();
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

        public DirectionType DirectionType { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
        [JsonProperty("Quantity")]
        public decimal Tradeturnover { get; set; }
    }

    public class TradeTick
    {
        [JsonConstructor]
        public TradeTick(long id, long ts, List<TradeData> data)
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
        public List<TradeData> Data { get; set; }
    }


}