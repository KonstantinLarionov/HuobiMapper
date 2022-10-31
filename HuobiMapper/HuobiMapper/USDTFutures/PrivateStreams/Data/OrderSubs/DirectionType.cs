using System.Runtime.Serialization;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Data.OrderSubs
{
    public enum DirectionEnum
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "buy")]
        Buy,
        [EnumMember(Value = "sell")]
        Sell
    }
}