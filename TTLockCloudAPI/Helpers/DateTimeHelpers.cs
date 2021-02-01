using System;

namespace OrbitaTech
{
    internal static class DateTimeHelpers
    {
        public static DateTime UnixStartTime { get; }
            = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetUnixTimeInMilliseconds(this DateTime dateTime)
        {
            return (long)dateTime.Subtract(UnixStartTime).TotalMilliseconds;
        }

        public static DateTime GetDateTimeFromUnixMilliseconds(this long unixTime)
        {
            return UnixStartTime.AddMilliseconds(unixTime);
        }
    }
}
