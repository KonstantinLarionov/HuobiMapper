using System.Globalization;

namespace HuobiMapper.Extensions
{
    internal static class DecimalExtensions
    {
        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo {NumberDecimalSeparator = @"."};
        public static string ToFormattedString(this decimal value) => value.ToString(NumberFormat);
    }
}
