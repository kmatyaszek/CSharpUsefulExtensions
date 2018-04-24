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

    }
}
