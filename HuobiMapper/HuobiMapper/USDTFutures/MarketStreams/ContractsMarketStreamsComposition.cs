using HuobiMapper.Extensions;
using HuobiMapper.USDTFutures.MarketStreams.Data;
using HuobiMapper.USDTFutures.MarketStreams.Events;

namespace HuobiMapper.USDTFutures.MarketStreams
{
    public class ContractsMarketStreamsComposition
    {
        public BaseEvent HandlerGetBaseEvent(string json) => 
            json.Deserialize<BaseEvent>();
        public OrderDepthEvent HandlerGetOrderDepthEvent(string json) => 
            json.Deserialize<OrderDepthEvent>();
        public TradeEvent HandlerGetOrderTradeEvent(string json) => 
            json.Deserialize<TradeEvent>();
    }
}