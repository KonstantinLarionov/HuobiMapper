using System.Runtime.Serialization;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Enums
{
    public enum PositionMarginMode
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "isolated")]
        Isolated,
        [EnumMember(Value = "cross")]
        Cross
    }
}