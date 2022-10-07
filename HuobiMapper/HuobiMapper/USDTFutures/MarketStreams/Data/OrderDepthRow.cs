using System.Security.Policy;
using HuobiMapper.USDTFutures.MarketStreams.Convertor;
using Newtonsoft.Json;

namespace HuobiMapper.USDTFutures.MarketStreams.Data
{
    [JsonConverter(typeof(OrderDepthRowConvertor))]
    public class OrderDepthRow
    {  
        public decimal Sell { get; set; }
        public decimal Buy { get; set; }
        
    }
}