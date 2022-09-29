using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum PositionSide
    {
        [EnumMember(Value = "")]
        Undef,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Long")]
        Long,
        [EnumMember(Value = "Short")]
        Short,
        [EnumMember(Value = "Buy")]
        Buy,
        [EnumMember(Value = "Sell")]
        Sell
    }
}