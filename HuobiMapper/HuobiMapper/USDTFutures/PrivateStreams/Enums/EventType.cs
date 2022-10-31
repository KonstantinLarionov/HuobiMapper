using System.Runtime.Serialization;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Enums
{
    public enum EventType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "snapshot")]
        Snapshot,
        [EnumMember(Value = "order.close")]
        OrderClose,
        [EnumMember(Value = "order.match")]
        OrderMatch,
        [EnumMember(Value = "settlement")]
        Settlement,
        [EnumMember(Value = "order.liquidation")]
        OrderLiquidation,
        [EnumMember(Value = "order.cancel")]
        OrderCancel,
        [EnumMember(Value = "switch_lever_rate")]
        SwitchLeverRate,
        [EnumMember(Value = "init")]
        Init
    }
}