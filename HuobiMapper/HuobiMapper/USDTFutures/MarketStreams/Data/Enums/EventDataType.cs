using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.MarketStreams.Data.Enums
{
    public enum EventDataType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "snapshot")]
        Snapshot,
        [EnumMember(Value = "incremental")]
        Incremental
    }
}