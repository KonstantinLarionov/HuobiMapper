using System;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.MarketStreams.Data;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Events
{
    public class OrderDepthEvent
    {
        [JsonConstructor]
        public OrderDepthEvent(string ch, Ticks tick, string id, string datatype)
        {
            Ch = ch;
            Tick = tick;
            Id = id;
            Datatype = datatype;
            TypeEnum = Datatype.ToEnum<EventDataType>();
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

        [JsonProperty("tick")]
        public Ticks Tick { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("data_type")]
        public string Datatype { get; set; }
        public EventDataType TypeEnum { get; }
    }
}