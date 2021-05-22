using System;

namespace DiscordBot.Core.DateTimes
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertToCest(this DateTime dateTime)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZone);
        }
    }
}