/*using System;
using HuobiMapper.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhemexMapper.Contracts.MarketStreams.Data;
using PhemexMapper.Contracts.MarketStreams.Data.Enums;
using PhemexMapper.Extensions;

namespace PhemexMapper.Contracts.MarketStreams.Convertors
{
    public class TradeRowConvertor: JsonConverter<TradeRow>
    {
        public override void WriteJson(JsonWriter writer, TradeRow value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override TradeRow ReadJson(JsonReader reader, Type objectType, TradeRow existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                throw new InvalidOperationException();
            }

            var array = (JArray) JToken.ReadFrom(reader);

            return new TradeRow
            { 
                Timestamp = (long)array[0],
                TradeSide = ((string)(array[1])).ToEnum<TradeSide>(),
                Price = (decimal)array[2],
                Qty = (int)array[3]
            };
        }

        public override bool CanWrite { get; } = false;
    }
}*/