using System.Runtime.Serialization;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Enums
{
    public enum PositionDirection
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "sell")]
        Sell,
        [EnumMember(Value = "buy")]
        Buy
    }
}