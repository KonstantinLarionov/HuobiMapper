using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum OrderSideType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "Buy")]
        Buy,
        [EnumMember(Value = "Sell")]
        Sell
    }
}