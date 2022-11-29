using System.Globalization;

namespace HuobiMapper.Extensions
{
    public static class PublicDecimalExtensions
    {
        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo {NumberDecimalSeparator = @"."};
        public static string ToFormattedStringPublic(this decimal value) => value.ToString(NumberFormat);
    }
}
