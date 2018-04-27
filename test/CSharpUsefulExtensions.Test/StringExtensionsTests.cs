using FluentAssertions;
using NUnit.Framework;

namespace CSharpUsefulExtensions.Test
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Left_EmptyString_ShouldReturnEmptyString()
        {
            var value = "";

            var result = value.Left(5);

            result.Should().BeEmpty();
        }

        [Test]
        public void Left_NullString_ShouldReturnNullString()
        {
            string value = null;

            var result = value.Left(5);

            result.Should().BeNull();
        }

        [Test]
        public void Left_StringWithLowerLengthThanGivenLength_ShouldReturnEntireString()
        {
            string value = "abcdef";

            var result = value.Left(10);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void Left_StringWithHigherLengthThanGivenLength_ShouldReturnLeftmostCharacters()
        {
            string value = "abcdefghijk";

            var result = value.Left(5);

            result.Should().BeEquivalentTo("abcde");
        }

        [Test]
        public void Right_EmptyString_ShouldReturnEmptyString()
        {
            var value = "";

            var result = value.Right(5);

            result.Should().BeEmpty();
        }

        [Test]
        public void Right_NullString_ShouldReturnNullString()
        {
            string value = null;

            var result = value.Right(5);

            result.Should().BeNull();
        }

        [Test]
        public void Right_StringWithLowerLengthThanGivenLength_ShouldReturnEntireString()
        {
            string value = "abcdef";

            var result = value.Right(10);

            result.Should().BeEquivalentTo(value);
        }

        [Test]
        public void Right_StringWithHigherLengthThanGivenLength_ShouldReturnRightmostCharacters()
        {
            string value = "abcdefghijk";

            var result = value.Right(5);

            result.Should().BeEquivalentTo("ghijk");
        }
    }
}
