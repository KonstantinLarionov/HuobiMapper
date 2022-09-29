using System.Globalization;

namespace HuobiMapper.USDTFutures.RestApi.Extensions
{
    internal static class DecimalExtensions
    {
        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo {NumberDecimalSeparator = @"."};
        public static string ToFormattedSstring(this decimal volue) => volue.ToString(NumberFormat);

    }
}