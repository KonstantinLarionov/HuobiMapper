using Huobi.SDK.Core.WSBase.PrivateStreams.Event;
using HuobiMapper.Extensions;

namespace Huobi.SDK.Core.WSBase.PrivateStreams
{
    public class PrivateStreamsComposition
    {
        public BaseEvent HandlerGetBaseEvent(string json) =>
            json.Deserialize<BaseEvent>();
        public PositionsEvent HandlerGetPositions(string json) =>
            json.Deserialize<PositionsEvent>();
        public OrdersEvent HandlerGetOrders(string json) =>
            json.Deserialize<OrdersEvent>();
    }
}