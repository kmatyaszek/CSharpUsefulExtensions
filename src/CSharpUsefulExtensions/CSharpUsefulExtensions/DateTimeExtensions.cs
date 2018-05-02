using System;
using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<DateTime> IterateDayByDayTo(this DateTime startDate, DateTime endDate)
        {
            if (startDate.Date > endDate.Date)
                yield break;

            DateTime day = startDate;
            do
            {
                yield return day;
                day = day.AddDays(1);
            } while (day.Date <= endDate.Date);
        }

        public static IEnumerable<DateTime> IterateDayByDayFor(this DateTime startDate, int numOfDays)
        {
            if (numOfDays < 0)
                yield break;

            DateTime day = startDate;
                        
            int i = 0;
            do
            {
                yield return day;
                day = day.AddDays(1);
                i++;
            } while (i < numOfDays);
        }

        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        public static bool IsWorkingDayWithHolidayChecking(this DateTime date, IEnumerable<DateTime> holidays)
        {
            if (holidays == null)
                throw new ArgumentNullException("holidays");

            if (holidays.Count() == 0)
                throw new ArgumentException("List with holidays cannot be empty.", "holidays");

            return IsWorkingDay(date) && holidays.All(x => x.Date != x.Date);
        }
    }   
}