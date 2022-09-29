using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum ActionTradeType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "New")]
        New,
    }
}