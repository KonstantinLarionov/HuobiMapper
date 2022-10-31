using System.Security.Policy;
using HuobiMapper.USDTFutures.MarketStreams.Convertor;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Data
{
    [JsonConverter(typeof(OrderDepthRowConvertor))]
    public class OrderDepthRow
    {  
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        
    }
}