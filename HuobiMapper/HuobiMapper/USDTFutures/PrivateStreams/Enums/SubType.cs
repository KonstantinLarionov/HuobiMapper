using System.Runtime.Serialization;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Enums
{
    public enum SubType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "sub")]
        Subscribe,
        [EnumMember(Value = "unsub")]
        Unsubscribe
    }
}