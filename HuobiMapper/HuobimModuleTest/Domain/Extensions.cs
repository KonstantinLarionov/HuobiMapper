using System;

namespace ClassLibrary1.Domain
{
    public static class Extensions
    {
        private static DateTime unix_epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToUnixTimeMilliseconds(this DateTime value) =>
            (long) (value - unix_epoch).TotalMilliseconds;

        public static long ToUnixTimeSeconds(this DateTime value) =>
            (long) (value - unix_epoch).TotalSeconds;

        public static DateTime ToDateTimeFromUnixTimeMillisecond(this long value) =>
            DateTimeOffset.FromUnixTimeMilliseconds(value).DateTime;

        public static DateTime ToDateTimeFromUnixTimeSeconds(this long value) =>
            DateTimeOffset.FromUnixTimeSeconds(value).DateTime;

    }
}