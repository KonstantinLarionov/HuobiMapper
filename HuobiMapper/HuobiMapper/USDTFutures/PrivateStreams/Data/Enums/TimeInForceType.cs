using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum TimeInForceType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "GoodTillCancel")]
        GoodTillCancel,
        [EnumMember(Value = "PostOnly")]
        PostOnly,
        [EnumMember(Value = "ImmediateOrCancel")]
        ImmediateOrCancel,
        [EnumMember(Value = "FillOrKill")]
        FillOrKill,
    }
}