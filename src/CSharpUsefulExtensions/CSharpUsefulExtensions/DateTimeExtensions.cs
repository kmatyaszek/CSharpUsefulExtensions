using System;

namespace CSharpUsefulExtensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDayOfTheMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
        }

        public static DateTime FirstDayOfTheMonthWithTime(this DateTime dateTime, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, hour, minute, second, millisecond);
        }

        public static DateTime LastDayOfTheMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
        }

        public static DateTime LastDayOfTheMonthWithTime(this DateTime dateTime, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), hour, minute, second, millisecond);
        }

        public static DateTime WithTime(this DateTime dateTime, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, second, millisecond);
        }
    }
}
