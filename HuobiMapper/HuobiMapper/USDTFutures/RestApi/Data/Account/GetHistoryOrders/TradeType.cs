using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.GetHistoryOrders
{
    public enum TradeType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "0")]
        All = 0,
        [EnumMember(Value = "1")]
        OpenLong = 1,
        [EnumMember(Value = "2")]
        OpenShort = 2,
        [EnumMember(Value = "3")]
        CloseShort = 3,
        [EnumMember(Value = "4")]
        CloseLong = 4,
        [EnumMember(Value = "5")]
        LiquidateLong = 5,
        [EnumMember(Value = "6")]
        LiquidateShort = 6,
        [EnumMember(Value = "17")]
        BuyOneWay = 17,
        [EnumMember(Value = "18")]
        SellOneWay = 18,
    }
}