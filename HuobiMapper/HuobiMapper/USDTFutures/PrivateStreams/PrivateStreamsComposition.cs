using Huobi.SDK.Core.WSBase.PrivateStreams.Event;
using HuobiMapper.Extensions;

namespace HuobiMapper.USDTFutures.PrivateStreams
{
    public class PrivateStreamsComposition
    {
        public BaseEvent HandlerGetBaseEvent(string json) =>
            json.Deserialize<BaseEvent>();
        public PositionsEvent HandlerGetPositions(string json) =>
            json.Deserialize<PositionsEvent>();
        public OrdersEvent HandlerGetOrders(string json) =>
            json.Deserialize<OrdersEvent>();
        public TradeEvent HandlerGetTrades(string json) =>
            json.Deserialize<TradeEvent>();
    }
}