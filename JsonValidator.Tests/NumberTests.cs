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

        [Fact]
        public void MatchWhenFractionShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match(".45");

            Assert.False(obtainedResult.Success());
            Assert.Equal(".45", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenIntegerPlusExponentShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Number().Match("234E5");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenIntegerPlusExponentWithSignShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Number().Match("234E-5");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenIntegerPlusWrongExponentShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Number().Match("234E.5");

            Assert.True(obtainedResult.Success());
            Assert.Equal("E.5", obtainedResult.RemainingText());
        }
        [Fact]
        public void MatchWhenExponentShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match("E+5");

            Assert.False(obtainedResult.Success());
            Assert.Equal("E+5", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenFractionPlusExponentShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match(".56E+5");

            Assert.False(obtainedResult.Success());
            Assert.Equal(".56E+5", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
