using FluentAssertions;
using NUnit.Framework;
using System;

namespace CSharpUsefulExtensions.Test
{
    [TestFixture]
    public class ArgumentCheckingTests
    {      

        [Test]
        public void ThrowIfNull_NullArgumentWithoutParamName_ShouldThrowArgumentNullExceptionWithNullParamName()
        {
            string parameter = null;

            parameter.Invoking(x => x.ThrowIfNull())
                .Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().BeNull();
        }

        [Test]
        public void ThrowIfNull_NotNullArgumentWithoutParamName_ShouldNotThrowArgumentNullException()
        {
            string parameter = "parameter";

            parameter.Invoking(x => x.ThrowIfNull())
                .Should().NotThrow<ArgumentNullException>();
        }

        [Test]
        public void ThrowIfNull_NullArgumentWithParamNameAsString_ShouldThrowArgumentNullExceptionWithGivenParamName()
        {
            string parameter = null;

            string exceptionParameterName = "param";

            parameter.Invoking(x => x.ThrowIfNull(exceptionParameterName))
                .Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be(exceptionParameterName);
        }

        [Test]
        public void ThrowIfNull_NotNullArgumentWithParamNameAsString_ShouldNotThrowArgumentNullException()
        {
            string parameter = "parameter";

            parameter.Invoking(x => x.ThrowIfNull("param"))
                .Should().NotThrow<ArgumentNullException>();
        }

        [Test]
        public void ThrowIfNull_NullArgumentWithParamNameAsStringAndMessage_ShouldThrowArgumentNullExceptionWithGivenParamNameAndMessage()
        {
            string parameter = null;

            string exceptionMessage = "Exception message";
            string exceptionParameterName = "param";

            parameter.Invoking(x => x.ThrowIfNull(exceptionParameterName, exceptionMessage))
                .Should().Throw<ArgumentNullException>()
                .WithMessage(exceptionMessage + "*")
                .And.ParamName.Should().Be(exceptionParameterName);
        }


        [Test]
        public void ThrowIfNull_NotNullArgumentWithParamNameAsStringAndMessage_ShouldNotThrowArgumentNullException()
        {
            string parameter = "parameter";

            parameter.Invoking(x => x.ThrowIfNull("param", "Exception message"))
                .Should().NotThrow<ArgumentNullException>();
        }

        [Test]
        public void ThrowIfNull_NullParameterWithParamNameExpression_ShouldThrowArgumentNullExceptionWithGivenParamName()
        {
            string parameter = null;

            parameter.Invoking(x => x.ThrowIfNull(() => parameter))
                .Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("parameter");
        }

        [Test]
        public void ThrowIfNull_NotNullParameterWithParamNameExpression_ShouldNotThrowArgumentNullException()
        {
            string parameter = "parameter";

            parameter.Invoking(x => x.ThrowIfNull(() => parameter))
                .Should().NotThrow<ArgumentNullException>();
        }

        [Test]
        public void ThrowIfNull_NullParameterWithParamNameExpressionAndMessage_ShouldThrowArgumentNullExceptionWithGivenParamNameAndMessage()
        {
            string parameter = null;

            parameter.Invoking(x => x.ThrowIfNull(() => parameter, "Exception message"))
                .Should().Throw<ArgumentNullException>()
                .WithMessage("Exception message*")
                .And.ParamName.Should().Be("parameter");
        }

        [Test]
        public void ThrowIfNull_NotNullParameterWithParamNameExpressionAndMessage_ShouldNotThrowArgumentNullException()
        {
            string parameter = "parameter";

            parameter.Invoking(x => x.ThrowIfNull(() => parameter, "Exception message"))
                .Should().NotThrow<ArgumentNullException>();
        }
    }
}
