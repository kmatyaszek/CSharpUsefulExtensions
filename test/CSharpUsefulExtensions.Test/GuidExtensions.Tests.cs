using FluentAssertions;
using NUnit.Framework;
using System;

namespace CSharpUsefulExtensions.Test
{
    [TestFixture]
    public class GuidExtensions
    {
        [Test]
        public void IsEmpty_EmptyGuid_ShouldReturnTrue()
        {
            Guid guid;

            var isEmpty = guid.IsEmpty();

            isEmpty.Should().BeTrue();
        }

        [Test]
        public void IsEmpty_NotEmptyGuid_ShouldReturnFalse()
        {
            Guid guid = Guid.NewGuid();

            var isEmpty = guid.IsEmpty();

            isEmpty.Should().BeFalse();
        }
    }
}
