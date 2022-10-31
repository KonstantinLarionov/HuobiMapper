using System;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams
{
    public static class CombineSubscriber
    {
        public static string parametrs { get; set; }
        public static bool DataType;

        public static string CreateDepthSub(string symbol, EventType eventType, int size, EventDataType dataType)
        {
            var id = Guid.NewGuid().ToString();
            var sub = "market." + symbol.ToLower()+ "." + eventType.GetEnumMemberAttributeValue() + $".size_{size}." + "high_freq";
            var data_type = dataType.GetEnumMemberAttributeValue();
            return "{\"sub\": \""+sub+"\", \"data_type\": \""+data_type+"\", \"id\": \""+id+"\"}";
        }
        public static string CreateTicksSub(string symbol, EventType eventType)
        {
            var id = Guid.NewGuid().ToString();
            var sub = "market." + symbol.ToUpper()+ "." + eventType.GetEnumMemberAttributeValue();
            return "{\"sub\": \""+sub+"\", \"id\": \""+id+"\"}";
        }

        // public static string CreateEventStringre(
        //     EventDataType eventDataType, 
        //     MarketType marketType,
        //     string symbolType,
        //     SubscribeType subscribeType,
        //     SizeType sizeType, params string[] symbol)
        //
        // {
        //     foreach (var item in symbol)
        //     {
        //         parametrs = item.ToString();
        //     }
        //
        //     if (DataType==false)
        //     {
        //
        //         var result = new
        //         {
        //             sub =
        //                 $"{eventDataType.GetEnumMemberAttributeValue()}{marketType.GetEnumMemberAttributeValue()}." +
        //                 $"{symbolType.ToString()}.{subscribeType.GetEnumMemberAttributeValue()}" +
        //                 $"{sizeType.GetEnumMemberAttributeValue()}.{parametrs.ToString()}",
        //             id = Guid.NewGuid().ToString()
        //         };
        //         return JsonConvert.SerializeObject(result);
        //     }
        //     else
        //     {
        //         var result = new
        //         {
        //             sub =
        //                 $"{eventDataType.GetEnumMemberAttributeValue()}{marketType.GetEnumMemberAttributeValue()}." +
        //                 $"{symbolType.ToString()}.{subscribeType.GetEnumMemberAttributeValue()}." +
        //                 $"{sizeType.GetEnumMemberAttributeValue()}.{parametrs.ToString()}",
        //             data_type = "incremental",
        //             id = Guid.NewGuid().ToString()
        //         };
        //         return JsonConvert.SerializeObject(result);
        //     }
        // }
    }
}