using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum TradeType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "Trade")]Trade,
        [EnumMember(Value = "Funding")]Funding,
        [EnumMember(Value = "AdlTrade")]AdlTrade,
        [EnumMember(Value = "LiqTrade")]LiqTrade
    }
}