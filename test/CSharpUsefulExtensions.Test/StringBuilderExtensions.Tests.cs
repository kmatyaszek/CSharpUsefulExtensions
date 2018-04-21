using FluentAssertions;
using NUnit.Framework;
using System;
using System.Text;

namespace CSharpUsefulExtensions.Tests
{
    [TestFixture]
    public class StringBuilderExtensions
    {
		[Test]
        public void IsEmpty_CreateObjectWithDefaultConstructor_ShouldReturnTrue()
        {
            StringBuilder builder = new StringBuilder();

            var isEmpty = builder.IsEmpty();

            isEmpty.Should().BeTrue();
        }

        [Test]
        public void IsEmpty_CreateObjectWithInitText_ShouldReturnFalse()
        {
            StringBuilder builder = new StringBuilder("test");

            var isEmpty = builder.IsEmpty();

            isEmpty.Should().BeFalse();
        }

        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("\t")]
        [TestCase("\t\t")]
        [TestCase("\r\n")]
        public void IsEmpty_ObjectWithWhiteSpace_ShouldReturnFalse(string whiteSpace)
        {
            StringBuilder builder = new StringBuilder(whiteSpace);

            var isEmpty = builder.IsEmpty();

            isEmpty.Should().BeFalse();
        }

        [Test]
        public void IsEmpty_InvokedOnNullReference_ShouldThrowNullReferenceException()
        {
            StringBuilder builder = null;

            Action isEmptyAction = () => { var isEmpty = builder.IsEmpty(); };

            isEmptyAction.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void IsNullOrEmpty_InvokedOnNullReference_ShouldReturnTrue()
        {
            StringBuilder builder = null;

            var isEmpty = builder.IsNullOrEmpty();

            isEmpty.Should().BeTrue();
        }

        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("\t")]
        [TestCase("\t\t")]
        [TestCase("\r\n")]
        public void IsNullOrWhiteSpace_ObjectWithOnlyWhiteSpaces_ShouldReturnTrue(string whiteSpace)
        {
            StringBuilder builder = new StringBuilder(whiteSpace);

            var isEmpty = builder.IsNullOrWhiteSpace();

            isEmpty.Should().BeTrue();
        }

        [Test]
        public void IsNullOrWhiteSpace_InvokedOnNullReference_ShouldReturnTrue()
        {
            StringBuilder builder = null;

            var isEmpty = builder.IsNullOrWhiteSpace();

            isEmpty.Should().BeTrue();
        }

        [Test]
        public void IsNullOrWhiteSpace_InvokedOnMultiLineText_ShouldReturnFalse()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Line1");
            builder.AppendLine("Line2");
            builder.AppendLine("Line3");

            var isEmpty = builder.IsNullOrWhiteSpace();

            isEmpty.Should().BeFalse();
        }
    }
}
