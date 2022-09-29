using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum EventType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "user")]
        UserLogin,
        [EnumMember(Value = "aop")]
        AccountOrderPosition,
    }
}