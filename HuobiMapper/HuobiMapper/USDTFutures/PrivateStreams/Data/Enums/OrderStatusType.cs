using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum OrderStatusType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "Untriggered")]
        Untriggered,
        [EnumMember(Value = "Triggered")]
        Triggered,
        [EnumMember(Value = "Rejected")]
        Rejected,
        [EnumMember(Value = "Created")]
        Created	,
        [EnumMember(Value = "New")]
        New	,
        [EnumMember(Value = "PartiallyFilled")]
        PartiallyFilled,
        [EnumMember(Value = "Filled")]
        Filled,
        [EnumMember(Value = "Canceled")]
        Canceled,
    }
}