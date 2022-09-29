using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Enums
{
    public enum ResponseStatus
    {
        [EnumMember(Value = "")]
        None = 0,
        [EnumMember(Value = "ok")]
        Ok = 1,
        [EnumMember(Value = "error")]
        Error = 2
    }
}