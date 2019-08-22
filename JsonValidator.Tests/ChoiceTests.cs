using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ChoiceTests
    {
        static Choice digit = new Choice(
                new Character('0'),
                new Range('1', '9')
        );

        static Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
        );

        [Fact]
        public void MatchWhenStartsWithDigitCharacterShouldReturnTrue()
        {
            Assert.True(digit.Match("012"));
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfDigitRangeShouldReturnTrue()
        {
            Assert.True(digit.Match("12"));
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfDigitRangeShouldReturnTrue()
        {
            Assert.True(digit.Match("92"));
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfDigitRangeAndNotDigitCharacterShouldReturnFalse()
        {
            Assert.False(digit.Match("a9"));
        }

        [Fact]
        public void MatchWhenEmptyOnDigitShouldReturnFalse()
        {
            Assert.False(digit.Match(""));
        }

        [Fact]
        public void MatchWhenNullOnDigitShouldReturnFalse()
        {
            Assert.False(digit.Match(null));
        }

        [Fact]
        public void MatchWhenStartsWithHexDigitCharacterShouldReturnTrue()
        {
            Assert.True(hex.Match("012"));
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfHexDigitRangeShouldReturnTrue()
        {
            Assert.True(hex.Match("12"));
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfHexDigitRangeShouldReturnTrue()
        {
            Assert.True(hex.Match("92"));
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfFirstHexRangeShouldReturnTrue()
        {
            Assert.True(hex.Match("a9"));
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfFirstHexRangeShouldReturnTrue()
        {
            Assert.True(hex.Match("f8"));
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfSecondHexRangeShouldReturnTrue()
        {
            Assert.True(hex.Match("A9"));
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfSecondHexRangeShouldReturnTrue()
        {
            Assert.True(hex.Match("F8"));
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfFirstHexRangeAndNotSecondHexRangeDigitCharacterOrDigitRangeShouldReturnFalse()
        {
            Assert.False(hex.Match("g8"));
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfSecondHexRangeAndNotFirstHexRangeDigitCharacterOrDigitRangeShouldReturnFalse()
        {
            Assert.False(hex.Match("G8"));
        }

        [Fact]
        public void MatchWhenEmptyOnHexShouldReturnFalse()
        {
            Assert.False(hex.Match(""));
        }

        [Fact]
        public void MatchWhenNullOnHexShouldReturnFalse()
        {
            Assert.False(hex.Match(null));
        }
    }
}