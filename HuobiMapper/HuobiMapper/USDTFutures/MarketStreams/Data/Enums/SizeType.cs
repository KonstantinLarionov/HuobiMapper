using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.MarketStreams.Data.Enums
{
    public enum SizeType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "size_20")]
        Size_20,
        
    }
}