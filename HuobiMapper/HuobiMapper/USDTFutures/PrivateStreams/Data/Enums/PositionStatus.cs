using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum PositionStatus
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "Normal")]
        Normal
    }
}