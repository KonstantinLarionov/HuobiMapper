namespace HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders
{
    public enum TradeType
    {
        All = 0,
        OpenLong = 1,
        OpenShort = 2,
        CloseShort = 3,
        CloseLong = 4,
        LiquidateLong = 5,
        LiquidateShort = 6,
        BuyOneWay = 17,
        SellOneWay = 18,
    }
}