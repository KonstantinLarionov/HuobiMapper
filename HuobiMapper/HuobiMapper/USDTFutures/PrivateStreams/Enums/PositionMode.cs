using System.Runtime.Serialization;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Enums
{
    public enum PositionMode
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "single_side")]
        SingleSide,
        [EnumMember(Value = "dual_side")]
        DualSide
    }
}