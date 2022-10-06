using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.MarketStreams.Events;

namespace HuobiMapper.USDTFutures.MarketStreams
{
    public class ContractsMarketStreamsComposition
    {
        public BaseEvent HandlerGetBaseEvent(string json) => 
            json.Deserialize<BaseEvent>();
        public OrderDepthEvent HandlerGetOrderBookEvent(string json) => 
            json.Deserialize<OrderDepthEvent>();
    }
}