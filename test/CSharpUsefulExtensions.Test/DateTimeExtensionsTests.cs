using FluentAssertions;
using NUnit.Framework;
using System;

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

    }
}
