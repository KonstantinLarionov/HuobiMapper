using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders
{
    public enum OrderStatusEnum
    {
        None = 0,
        ReadyToSubmit = 1,
        ReadyToSubmit2 = 2,
        HaveSubmittedTheOrders = 3,
        OrdersPartiallyMatched = 4,
        OrdersCancelledWithPartiallyMatched = 5,
        OrdersFullyMatched = 6,
        OrdersCancelled = 7,
        OrdersFailed = 10,
        OrdersCancelling = 11
    }
}