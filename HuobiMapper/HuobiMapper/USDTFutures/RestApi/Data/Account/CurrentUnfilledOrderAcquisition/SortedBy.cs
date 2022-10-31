using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition
{
    public enum SortedBy
    {
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "update_time")]
        UpdateTime
    }
}