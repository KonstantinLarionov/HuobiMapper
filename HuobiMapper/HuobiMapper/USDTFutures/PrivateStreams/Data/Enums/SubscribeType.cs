using System.Runtime.Serialization;

namespace HuobiMapper.USDTFutures.PrivateStreams.Data.Enums
{
    public enum SubscribeType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "auth")]
        Auth,
        [EnumMember(Value = "subscribe")]
        Subscribe,
        [EnumMember(Value = "unsubscribe")]
        Unsubscribe
    }
}