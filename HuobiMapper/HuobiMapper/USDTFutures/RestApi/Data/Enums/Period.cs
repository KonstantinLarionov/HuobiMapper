using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace HuobiMapper.USDTFutures.RestApi.Data.Enums
{
    public enum Period
    {
        [EnumMember(Value = "")]
        Unrecognized,
        [EnumMember(Value = "1min"), UsedImplicitly]
        OneMinute,
        [EnumMember(Value = "5min"), UsedImplicitly]
        FiveMinute,
        [EnumMember(Value = "15min"), UsedImplicitly]
        FifteenMinute,
        [EnumMember(Value = "30min"), UsedImplicitly]
        ThirtyMinute,
        [EnumMember(Value = "60min"), UsedImplicitly]
        OneHour,
        [EnumMember(Value = "4hour"), UsedImplicitly]
        FourHour,
        [EnumMember(Value = "1day"), UsedImplicitly]
        OneDay,
        [EnumMember(Value = "1mon"), UsedImplicitly]
        OneMonth,
    }

   
}