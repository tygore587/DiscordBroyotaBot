using System;
using TimeZoneConverter;

namespace DiscordBot.Core.DateTimes
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertToCest(this DateTime dateTime)
        {
            var timeZone = TZConvert.GetTimeZoneInfo("Europe/Berlin");

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, timeZone);
        }
    }
}