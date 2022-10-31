using System;
using HuobiMapper.USDTFutures.MarketStreams.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuobiMapper.USDTFutures.MarketStreams.Convertor
{
    public class OrderDepthRowConvertor : JsonConverter<OrderDepthRow>
    {
        public override void WriteJson(JsonWriter writer, OrderDepthRow value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override OrderDepthRow ReadJson(JsonReader reader, Type objectType, OrderDepthRow existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                throw new InvalidOperationException();
            }

            var array = (JArray) JToken.ReadFrom(reader);

            return new OrderDepthRow
            { 
                Price = (decimal)array[0],
                Volume = (decimal)array[1]
            };
        }

        public override bool CanWrite { get; } = false;

    }
}