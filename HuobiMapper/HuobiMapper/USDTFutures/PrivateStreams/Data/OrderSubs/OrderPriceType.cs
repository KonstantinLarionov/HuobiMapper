using System.Runtime.Serialization;

namespace Huobi.SDK.Core.WSBase.PrivateStreams.Data.OrderSubs
{
    public enum OrderPriceTypeEnum
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "limit")]
        Limit,
        [EnumMember(Value = "opponent")]
        Opponent,
        [EnumMember(Value = "post_only")]
        PostOnly,
        [EnumMember(Value = "lightning")]
        Lightning,
        [EnumMember(Value = "optimal_5")]
        Optimal5,
        [EnumMember(Value = "optimal_10")]
        Optimal10,
        [EnumMember(Value = "optimal_20")]
        Optimal20,
        [EnumMember(Value = "fok")]
        Fok,
        [EnumMember(Value = "ioc")]
        Ioc,
        [EnumMember(Value = "opponent_ioc")]
        OpponentIoc,
        [EnumMember(Value = "lightning_ioc")]
        LightningIoc,
        [EnumMember(Value = "optimal_5_ioc")]
        Optimal5Ioc,
        [EnumMember(Value = "optimal_10_ioc")]
        Optimal10Ioc,
        [EnumMember(Value = "optimal_20_ioc")]
        Optimal20Ioc,
        [EnumMember(Value = "opponent_fok")]
        OpponentFok,
        [EnumMember(Value = "lightning_fok")]
        LightningFok,
        [EnumMember(Value = "optimal_5_fok")]
        Optimal5Fok,
        [EnumMember(Value = "optimal_10_fok")]
        Optimal10Fok,
        [EnumMember(Value = "optimal_20_fok")]
        Optimal20Fok,
    }
}