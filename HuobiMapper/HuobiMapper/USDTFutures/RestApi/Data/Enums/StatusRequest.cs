using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Enums
{
    public enum StatusRequest
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "ok")]
        Ok,
        [EnumMember(Value = "error")]
        Error
    }
}