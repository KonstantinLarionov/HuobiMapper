using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum ExecutionStatusType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "TakerFill")]
        TakerFill,
        [EnumMember(Value = "MakerFill")]
        MakerFill,
        [EnumMember(Value = "PendingNew")]
        PendingNew,
        [EnumMember(Value = "PendingCancel")]
        PendingCancel
    }
}