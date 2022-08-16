using System;

namespace BeHeroes.CodeOps.Abstractions.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static double ToUnixTimeStamp(this DateTime date)
        {
            return (double)(date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds / 1000;
        }

        public static string ToISO8601(this DateTime date)
        {
            return date.ToUniversalTime().ToString("o");
        }

        public static DateTime UnixTimeStampToDateTime(this DateTime date, double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            date = date.AddSeconds(unixTimeStamp).ToLocalTime();
            return date;
        }
    }
}
