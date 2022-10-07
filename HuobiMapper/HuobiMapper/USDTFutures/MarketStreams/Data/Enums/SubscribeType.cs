using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.MarketStreams.Data.Enums
{
    public enum SubscribeType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "depth")]
        Depth,
        [EnumMember(Value = "trade")]
        Trade,
    }
}