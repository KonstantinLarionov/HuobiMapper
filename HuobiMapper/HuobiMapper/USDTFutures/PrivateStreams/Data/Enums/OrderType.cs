using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum OrderType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "Limit")]
        Limit,
        [EnumMember(Value = "Market")]
        Market,
        [EnumMember(Value = "Stop")]
        Stop,
        [EnumMember(Value = "StopLimit")]
        StopLimit,
        [EnumMember(Value = "MarketIfTouched")]
        MarketIfTouched,
        [EnumMember(Value = "LimitIfTouched")]
        LimitIfTouched
    }
}