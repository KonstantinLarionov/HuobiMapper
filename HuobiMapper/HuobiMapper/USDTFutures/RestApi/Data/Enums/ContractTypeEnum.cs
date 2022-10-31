using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Enums
{
    public enum ContractTypeEnum
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "swap")]
        Swap,
        [EnumMember(Value = "this_week")]
        ThisWeek,
        [EnumMember(Value = "next_week")]
        NextWeek,
        [EnumMember(Value = "quarter")]
        Quarter,
        [EnumMember(Value = "next_quarter")]
        NextQuarter
    }
}