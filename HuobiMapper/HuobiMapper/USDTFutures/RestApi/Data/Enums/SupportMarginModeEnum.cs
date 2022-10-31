using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Enums
{
    public enum SupportMarginModeEnum
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "cross")]
        Cross,
        [EnumMember(Value = "isolated")]
        Isolated,
        [EnumMember(Value = "all")]
        All
    }
}