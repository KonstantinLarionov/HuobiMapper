using System;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams
{
    public static class CombineSubscriber
    {
        public static string parametrs { get; set; }

        public static string CreateEventStringre(MarketType marketType,SymbolType symbolType, SubscribeType subscribeType, 
            SizeType sizeType, string symbol,EventDataType eventDataType)
        { 
            foreach (var item in symbol)
                     {
                         parametrs = item.ToString();
         
                     }
            var result = new
            {
                sub =
                    $"{marketType.GetEnumMemberAttributeValue()}.{symbolType.GetEnumMemberAttributeValue()}.{subscribeType.GetEnumMemberAttributeValue()}.{sizeType.GetEnumMemberAttributeValue()}.{parametrs.ToString()}",
                data_type= eventDataType.GetEnumMemberAttributeValue(),
                id=Guid.NewGuid().ToString()
            };
           
            return JsonConvert.SerializeObject(result);
        }   
    }
}