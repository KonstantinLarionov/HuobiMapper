using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.MarketStreams.Data.Enums
{
    public enum MarketType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "market")]
        Market,
    }
}