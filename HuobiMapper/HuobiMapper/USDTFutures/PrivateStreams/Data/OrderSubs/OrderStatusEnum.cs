namespace Huobi.SDK.Core.WSBase.PrivateStreams.Data.OrderSubs
{
    public enum OrderStatusEnum
    {
        None = 0,
        PlacingOrdersToOrderBook = 1,
        PlacingOrdersToOrderBook2 = 2,
        PlacedToOrderBook = 3,
        PartiallyFilled = 4,
        partiallyFilledButCancelledByClient = 5,
        FullyFilled = 6,
        Cancelled = 7,
        Cancelling = 11
    }
}