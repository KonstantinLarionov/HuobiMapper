using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.RestApi.Data.Account.CurrentUnfilledOrderAcquisition
{
    public enum DirectionEnum
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "buy")]
        Buy,
        [EnumMember(Value = "sell")]
        Sell
    }
}