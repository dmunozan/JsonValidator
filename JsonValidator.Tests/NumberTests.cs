using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class NumberTests
    {
        [Fact]
        public void MatchWhenOneNumberShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new Number().Match("2");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenMoreThanOneNumberAndNoStartsWithZeroShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new Number().Match("234");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenMoreThanOneNumberAndStartsWithZeroShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Number().Match("0234");

            Assert.True(obtainedResult.Success());
            Assert.Equal("234", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithMinusSignShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Number().Match("-234");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithLettersShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match("R234");

            Assert.False(obtainedResult.Success());
            Assert.Equal("R234", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenIntegerPlusFractionShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Number().Match("234.25");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenIntegerPlusPointAndNotNumberShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Number().Match("234.R5");

            Assert.True(obtainedResult.Success());
            Assert.Equal(".R5", obtainedResult.RemainingText());
        }
    }
}
