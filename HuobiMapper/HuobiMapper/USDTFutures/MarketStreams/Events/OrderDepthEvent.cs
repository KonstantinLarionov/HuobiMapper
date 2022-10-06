using System;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.MarketStreams.Data;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Events
{
    public class OrderDepthEvent
    {   [JsonConstructor]
        public OrderDepthEvent(SubIncrementalhData ch, string datatype, long id)
        {
            Ch = ch;
            Id = id;
            Datatype = datatype;
            TypeEnum=Datatype.ToEnum<EventDataType>();
        }
        [JsonProperty("ch")]
        public SubIncrementalhData Ch { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("data_type")]
        public string Datatype { get; set; }
        public EventDataType TypeEnum { get; }
    }
}