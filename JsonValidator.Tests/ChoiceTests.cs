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

        [Fact]
        public void MatchWhenStartsWithDigitCharacterShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = digit.Match("012");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("12", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfDigitRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = digit.Match("12");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("2", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfDigitRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = digit.Match("92");

            Assert.True(obtainedResult.Success());
            Assert.Equal("2", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfDigitRangeAndNotDigitCharacterShouldReturnFalseAndText()
        {
            IMatch obtainedResult = digit.Match("a9");

            Assert.False(obtainedResult.Success());
            Assert.Equal("a9", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyOnDigitShouldReturnFalseAndText()
        {
            IMatch obtainedResult = digit.Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullOnDigitShouldReturnFalseAndText()
        {
            IMatch obtainedResult = digit.Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }

        static Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
        );

        [Fact]
        public void MatchWhenStartsWithHexDigitCharacterShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hex.Match("012");

            Assert.True(obtainedResult.Success());
            Assert.Equal("12", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfHexDigitRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hex.Match("12");

            Assert.True(obtainedResult.Success());
            Assert.Equal("2", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfHexDigitRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hex.Match("92");

            Assert.True(obtainedResult.Success());
            Assert.Equal("2", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfFirstHexRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hex.Match("a9");

            Assert.True(obtainedResult.Success());
            Assert.Equal("9", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfFirstHexRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hex.Match("f8");

            Assert.True(obtainedResult.Success());
            Assert.Equal("8", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfSecondHexRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "9");
            Match obtainedResult = (Match)hex.Match("A9");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfSecondHexRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "8");
            Match obtainedResult = (Match)hex.Match("F8");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfFirstHexRangeAndNotSecondHexRangeDigitCharacterOrDigitRangeShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "g8");
            Match obtainedResult = (Match)hex.Match("g8");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfSecondHexRangeAndNotFirstHexRangeDigitCharacterOrDigitRangeShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "G8");
            Match obtainedResult = (Match)hex.Match("G8");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenEmptyOnHexShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "");
            Match obtainedResult = (Match)hex.Match("");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenNullOnHexShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, null);
            Match obtainedResult = (Match)hex.Match(null);
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }
    }
}