using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.MarketStreams.Data.Enums
{
    public enum DirectionType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "sell")]
        Sell,
        [EnumMember(Value = "buy")]
        Buy
    }
}