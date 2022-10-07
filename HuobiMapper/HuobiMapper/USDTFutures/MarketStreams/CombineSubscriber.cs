using System;
using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.MarketStreams.Data.Enums;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams
{
    public static class CombineSubscriber
    {
        public static string parametrs { get; set; }
        /*public static EventDataType eventDataType=new EventDataType() ;*/
        public static bool DataType;
        public static string CreateEventStringre(EventDataType eventDataType, MarketType marketType,
            string symbolType,
            SubscribeType subscribeType,
            SizeType sizeType, params string[] symbol)

        {
            foreach (var item in symbol)
            {
                parametrs = item.ToString();

            }

            if (DataType==false)
            {

                var result = new
                {
                    sub =
                        $"{eventDataType.GetEnumMemberAttributeValue()}{marketType.GetEnumMemberAttributeValue()}." +
                        $"{symbolType.ToString()}.{subscribeType.GetEnumMemberAttributeValue()}." +
                        $"{sizeType.GetEnumMemberAttributeValue()}.{parametrs.ToString()}",
                    id = "id7"
                };
                return JsonConvert.SerializeObject(result);
            }
            else
            {
                var result = new
                {
                    sub =
                        $"{eventDataType.GetEnumMemberAttributeValue()}{marketType.GetEnumMemberAttributeValue()}." +
                        $"{symbolType.ToString()}.{subscribeType.GetEnumMemberAttributeValue()}." +
                        $"{sizeType.GetEnumMemberAttributeValue()}.{parametrs.ToString()}",
                    data_type = "incremental",
                    id = Guid.NewGuid().ToString()
                };
                return JsonConvert.SerializeObject(result);
            } 

            
        }
    }
}