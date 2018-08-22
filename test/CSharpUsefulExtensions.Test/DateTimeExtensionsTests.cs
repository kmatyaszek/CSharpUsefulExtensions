using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharpUsefulExtensions.Test
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void FirstDayOfTheMonth_GivenDateTime_ShouldReturnDateTimeWithFirstDayOfTheMonth()
        {
            var dateTime = new DateTime(2018, 4, 23, 15, 15, 15, 15);

            var result = dateTime.FirstDayOfTheMonth();

            result.Should().Be(new DateTime(2018, 4, 1, 15, 15, 15, 15));
        }

        [Test]
        public void FirstDayOfTheMonthWithTime_WithoutGivenTime_ShouldReturnFirstDayOfTheMonthAtMidnight()
        {
            var dateTime = new DateTime(2018, 4, 23, 15, 15, 15, 15);

            var result = dateTime.FirstDayOfTheMonthWithTime();

            result.Should().Be(new DateTime(2018, 4, 1, 0, 0, 0, 0));
        }

        [Test]
        public void FirstDayOfTheMonthWithTime_WithGivenTime_ShouldReturnDateTimeWithFirstDayOfTheMonthAndGivenTime()
        {
            var dateTime = new DateTime(2018, 4, 23, 15, 15, 15, 15);

            var result = dateTime.FirstDayOfTheMonthWithTime(12, 12, 12, 12);

            result.Should().Be(new DateTime(2018, 4, 1, 12, 12, 12, 12));
        }

        [Test]
        public void LastDayOfTheMonth_GivenDateTime_ShouldReturnDateTimeWithLastDayOfTheMonth()
        {
            var dateTime = new DateTime(2018, 4, 23, 15, 15, 15, 15);

            var result = dateTime.LastDayOfTheMonth();

            result.Should().Be(new DateTime(2018, 4, 30, 15, 15, 15, 15));
        }

        [Test]
        public void LastDayOfTheMonthWithTime_WithoutGivenTime_ShouldReturnLastDayOfTheMonthAtMidnight()
        {
            var dateTime = new DateTime(2018, 4, 23, 15, 15, 15, 15);

            var result = dateTime.LastDayOfTheMonthWithTime();

            result.Should().Be(new DateTime(2018, 4, 30, 0, 0, 0, 0));
        }

        [Test]
        public void LastDayOfTheMonthWithTime_WithGivenTime_ShouldReturnDateTimeWithLastDayOfTheMonthAndGivenTime()
        {
            var dateTime = new DateTime(2018, 4, 23, 15, 15, 15, 15);

            var result = dateTime.LastDayOfTheMonthWithTime(12, 12, 12, 12);

            result.Should().Be(new DateTime(2018, 4, 30, 12, 12, 12, 12));
        }

        [Test]
        public void WithTime_GivenTime_ShouldReturnDateTimeWithGivenTime()
        {
            var dateTime = new DateTime(2018, 4, 24, 20, 07, 32);

            var result = dateTime.WithTime(21, 15, 10);

            result.Should().Be(new DateTime(2018, 4, 24, 21, 15, 10));
        }

        [Test]
        public void IterateDayByDayTo_StartDateIsGreaterThanEndDate_ShouldReturnEmptyList()
        {
            var startDate = new DateTime(2018, 4, 30);
            var endDate = new DateTime(2017, 4, 29);

            var result = startDate.IterateDayByDayTo(endDate);

            result.Should().BeEmpty();
        }

        [Test]
        public void IterateDayByDayTo_StartDateAndEndDateAreEquals_ShouldReturnOnlyOneDay()
        {
            var startDate = new DateTime(2018, 4, 30);
            var endDate = new DateTime(2018, 4, 30);

            var result = startDate.IterateDayByDayTo(endDate);

            result.Should().NotBeEmpty()
                .And.HaveCount(1)
                .And.ContainInOrder(new[] { new DateTime(2018, 4, 30) })
                .And.ContainItemsAssignableTo<DateTime>();
        }

        [Test]
        public void IterateDayByDayTo_StartDateEquals1April2018AndEndDateEquals7April2018_ShouldReturn7Days()
        {
            var startDate = new DateTime(2018, 4, 1);
            var endDate = new DateTime(2018, 4, 7);

            var result = startDate.IterateDayByDayTo(endDate);

            result.Should().NotBeEmpty()
                .And.HaveCount(7)
                .And.ContainInOrder(new[] { new DateTime(2018, 4, 1), new DateTime(2018, 4, 2), new DateTime(2018, 4, 3), new DateTime(2018, 4, 4),
                    new DateTime(2018, 4, 5), new DateTime(2018, 4, 6), new DateTime(2018, 4, 7) })
                .And.ContainItemsAssignableTo<DateTime>();
        }

        [Test]
        public void IterateDayByDayFor_NumOfDaysIsNegative_ShouldReturnEmpty()
        {
            var startDate = new DateTime(2018, 5, 2);
            int numOfDays = -7;
            
            var result = startDate.IterateDayByDayFor(numOfDays);

            result.Should().BeEmpty();
        }

        [Test]
        public void IterateDayByDayFor_NumOfDaysEquals0_ShouldReturn1Day()
        {
            var startDate = new DateTime(2018, 5, 2);
            int numOfDays = 0;

            var result = startDate.IterateDayByDayFor(numOfDays);

            result.Should().NotBeEmpty()
               .And.HaveCount(1)
               .And.ContainInOrder(new[] { new DateTime(2018, 5, 2) })
               .And.ContainItemsAssignableTo<DateTime>();
        }

        [Test]
        public void IterateDayByDayFor_NumOfDaysEquals7_ShouldReturn7Days()
        {
            var startDate = new DateTime(2018, 5, 2);
            int numOfDays = 7;

            var result = startDate.IterateDayByDayFor(numOfDays);

            result.Should().NotBeEmpty()
               .And.HaveCount(7)
               .And.ContainInOrder(new[] { new DateTime(2018, 5, 2), new DateTime(2018, 5, 3), new DateTime(2018, 5, 4), new DateTime(2018, 5, 5),
                    new DateTime(2018, 5, 6), new DateTime(2018, 5, 7), new DateTime(2018, 5, 8) })
               .And.ContainItemsAssignableTo<DateTime>();
        }

        [TestCase(2018, 5, 7)]
        [TestCase(2018, 5, 8)]
        [TestCase(2018, 5, 9)]
        [TestCase(2018, 5, 10)]
        [TestCase(2018, 5, 11)]
        public void IsWorkingDay_DateFromMondayToFriday_ShouldReturnTrue(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var result = date.IsWorkingDay();

            result.Should().BeTrue();
        }

        [TestCase(2018, 5, 5)]
        [TestCase(2018, 5, 6)]
        public void IsWorkingDay_DateSaturdayAndSunday_ShouldReturnFalse(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var result = date.IsWorkingDay();

            result.Should().BeFalse();
        }

        [Test]
        public void IsWorkingDayWithHolidayChecking_NullHolidaysList_ShouldReturnArgumentNullException()
        {
            var date = new DateTime(2018, 5, 7);
            List<DateTime> holidays = null;
            
            date.Invoking(d => d.IsWorkingDayWithHolidayChecking(holidays))
                .Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidays");            
        }

        [Test]
        public void IsWorkingDayWithHolidayChecking_EmptyHolidaysList_ShouldReturnArgumentException()
        {
            var date = new DateTime(2018, 5, 7);
            List<DateTime> holidays = new List<DateTime>();

            date.Invoking(d => d.IsWorkingDayWithHolidayChecking(holidays))
                .Should().Throw<ArgumentException>().And.ParamName.Should().Be("holidays");
        }

        [Test]
        public void IsWorkingDayWithHolidayChecking_MondayDateWithHolidayInThisDay_ShouldReturnFalse()
        {
            var date = new DateTime(2018, 5, 7);
            var holidays = new[] { date };

            var result = date.IsWorkingDayWithHolidayChecking(holidays);

            result.Should().BeFalse();
        }

        [Test]
        public void NextDay_GivenDateTime_ShouldReturnGivenDateTimePlusOneDay()
        {
            var dateTime = new DateTime(2018, 5, 8);

            var result = dateTime.NextDay();

            result.Should().Be(new DateTime(2018, 5, 9));
        }

        [Test]
        public void PreviousDay_GivenDateTime_ShouldReturnGivenDateTimeMinusOneDay()
        {
            var dateTime = new DateTime(2018, 5, 8);

            var result = dateTime.PreviousDay();

            result.Should().Be(new DateTime(2018, 5, 7));
        }

        [Test]
        public void GetContinuousDaysRange_NullSource_ShouldReturnEmptyList()
        {
            IEnumerable<DateTime> source = null;

            var result = source.GetContinuousDaysRange();

            result.Should().BeEmpty();
        }

        [Test]
        public void GetContinuousDaysRange_SourceWithOneDay_ShouldReturnListWithOneItem()
        {
            DateTime dateTime = new DateTime(2018, 5, 7);
            IEnumerable<DateTime> source = new List<DateTime>() { dateTime };

            var result = source.GetContinuousDaysRange();

            result.Should().NotBeEmpty()
                    .And.HaveCount(1)
                    .And.OnlyContain(x => x.StartDateTime == dateTime && x.EndDateTime == dateTime);
        }

        [Test]
        public void GetContinuousDaysRange_SourceWithTwoNotContinuousDays_ShouldReturnListWithTwoItems()
        {
            DateTime firstDate = new DateTime(2018, 5, 7);
            DateTime secondDate = new DateTime(2018, 5, 10);
            IEnumerable<DateTime> source = new List<DateTime>() { firstDate, secondDate };

            var result = source.GetContinuousDaysRange();

            result.Should().NotBeEmpty()
                    .And.HaveCount(2)
                    .And.Contain(x => x.StartDateTime == firstDate && x.EndDateTime == firstDate)
                    .And.Contain(x => x.StartDateTime == secondDate && x.EndDateTime == secondDate);
        }

        [Test]
        public void GetContinuousDaysRange_SourceWithThreeContinuousDays_ShouldReturnListWithOneItem()
        {
            DateTime firstDay = new DateTime(2018, 5, 7);
            DateTime secondDay = new DateTime(2018, 5, 8);
            DateTime thirdDay = new DateTime(2018, 5, 9);
            IEnumerable<DateTime> source = new List<DateTime>() { firstDay, secondDay, thirdDay };

            var result = source.GetContinuousDaysRange();

            result.Should().NotBeEmpty()
                    .And.HaveCount(1)
                    .And.Contain(x => x.StartDateTime == firstDay && x.EndDateTime == thirdDay);
        }

        [Test]
        public void GetContinuousDaysRange_SourceWithTwoNotContinuousRanges_ShouldReturnListWithTwoItems()
        {
            DateTime firstDayFirstRange = new DateTime(2018, 5, 7);
            DateTime secondDayFirstRange = new DateTime(2018, 5, 8);
            DateTime thirdDayFirstRange = new DateTime(2018, 5, 9);
            DateTime firstDaySecondRange = new DateTime(2018, 6, 7);
            DateTime secondDaySecondRange = new DateTime(2018, 6, 8);
            DateTime thirdDaySecondRange = new DateTime(2018, 6, 9);
            DateTime fourthDaySecondRange = new DateTime(2018, 6, 10);
            DateTime fifthDaySecondRange = new DateTime(2018, 6, 11);

            IEnumerable<DateTime> source = new List<DateTime>() { firstDayFirstRange, secondDayFirstRange, thirdDayFirstRange,
                        firstDaySecondRange, secondDaySecondRange, thirdDaySecondRange, fourthDaySecondRange, fifthDaySecondRange };

            var result = source.GetContinuousDaysRange();

            result.Should().NotBeEmpty()
                    .And.HaveCount(2)
                    .And.Contain(x => x.StartDateTime == firstDayFirstRange && x.EndDateTime == thirdDayFirstRange)
                    .And.Contain(x => x.StartDateTime == firstDaySecondRange && x.EndDateTime == fifthDaySecondRange);
        }

        [Test]
        public void GetContinuousDaysRange_SourceWithTwoNotContinuousRangesAndFewDayWithDifferentTime_ShouldReturnListWithTwoItems()
        {
            DateTime firstDayFirstRangeTime1 = new DateTime(2018, 5, 7, 7, 0, 0);
            DateTime firstDayFirstRangeTime2 = new DateTime(2018, 5, 7, 15, 0, 0);
            DateTime secondDayFirstRange = new DateTime(2018, 5, 8);
            DateTime thirdDayFirstRangeTime1 = new DateTime(2018, 5, 9, 16, 0, 0);
            DateTime thirdDayFirstRangeTime2 = new DateTime(2018, 5, 9, 17, 0, 0);
            DateTime thirdDayFirstRangeTime3 = new DateTime(2018, 5, 9, 18, 0, 0);
            DateTime firstDaySecondRange = new DateTime(2018, 6, 7);
            DateTime secondDaySecondRange = new DateTime(2018, 6, 8);
            DateTime thirdDaySecondRange = new DateTime(2018, 6, 9);
            DateTime fourthDaySecondRangeTime1 = new DateTime(2018, 6, 10, 10, 0, 0);
            DateTime fourthDaySecondRangeTime2 = new DateTime(2018, 6, 10, 13, 0, 0);
            DateTime fifthDaySecondRangeTime1 = new DateTime(2018, 6, 11, 15, 0, 0);
            DateTime fifthDaySecondRangeTime2 = new DateTime(2018, 6, 11, 16, 0, 0);
            DateTime fifthDaySecondRangeTime3 = new DateTime(2018, 6, 11, 20, 0, 0);
            DateTime fifthDaySecondRangeTime4 = new DateTime(2018, 6, 11, 22, 0, 0);

            IEnumerable<DateTime> source = new List<DateTime>() { firstDayFirstRangeTime1, firstDayFirstRangeTime2, secondDayFirstRange, thirdDayFirstRangeTime1,
                thirdDayFirstRangeTime2, thirdDayFirstRangeTime3, firstDaySecondRange, secondDaySecondRange, thirdDaySecondRange, fourthDaySecondRangeTime1,
                fourthDaySecondRangeTime2, fifthDaySecondRangeTime1, fifthDaySecondRangeTime2, fifthDaySecondRangeTime3, fifthDaySecondRangeTime4 };

            var result = source.GetContinuousDaysRange();

            result.Should().NotBeEmpty()
                    .And.HaveCount(2)
                    .And.Contain(x => x.StartDateTime == firstDayFirstRangeTime1 && x.EndDateTime == thirdDayFirstRangeTime3)
                    .And.Contain(x => x.StartDateTime == firstDaySecondRange && x.EndDateTime == fifthDaySecondRangeTime4);
        }

        [Test]
        public void IsToday_YesterdayDate_ShouldReturnFalse()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);

            var result = yesterday.IsToday();

            result.Should().BeFalse();
        }

        [Test]
        public void IsToday_TomorrowDate_ShouldReturnFalse()
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);

            var result = tomorrow.IsToday();

            result.Should().BeFalse();
        }

        [Test]
        public void IsToday_TodayDate_ShouldReturnTrue()
        {
            DateTime today = DateTime.Now;

            var result = today.IsToday();

            result.Should().BeTrue();
        }

        [Test]
        public void IsPastDate_TodayDate_ShouldReturnFalse()
        {
            DateTime today = DateTime.Now;

            var result = today.IsPastDate();

            result.Should().BeFalse();
        }

        [Test]
        public void IsPastDate_YesterdayDate_ShouldReturnTrue()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);

            var result = yesterday.IsPastDate();

            result.Should().BeTrue();
        }

        [Test]
        public void IsFutureDate_TodayDate_ShouldReturnFalse()
        {
            DateTime today = DateTime.Now;

            var result = today.IsFutureDate();

            result.Should().BeFalse();
        }

        [Test]
        public void IsFutureDate_TomorrowDate_ShouldReturnTrue()
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);

            var result = tomorrow.IsFutureDate();

            result.Should().BeTrue();
        }
    }
}
