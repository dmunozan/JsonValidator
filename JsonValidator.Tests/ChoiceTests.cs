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
            IMatch obtainedResult = hex.Match("A9");

            Assert.True(obtainedResult.Success());
            Assert.Equal("9", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfSecondHexRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hex.Match("F8");

            Assert.True(obtainedResult.Success());
            Assert.Equal("8", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfFirstHexRangeAndNotSecondHexRangeDigitCharacterOrDigitRangeShouldReturnFalseAndText()
        {
            IMatch obtainedResult = hex.Match("g8");

            Assert.False(obtainedResult.Success());
            Assert.Equal("g8", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfSecondHexRangeAndNotFirstHexRangeDigitCharacterOrDigitRangeShouldReturnFalseAndText()
        {
            IMatch obtainedResult = hex.Match("G8");

            Assert.False(obtainedResult.Success());
            Assert.Equal("G8", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyOnHexShouldReturnFalseAndText()
        {
            IMatch obtainedResult = hex.Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullOnHexShouldReturnFalseAndText()
        {
            IMatch obtainedResult = hex.Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }

        static IPattern someLetters = new Choice(
                new Range('g', 'k'),
                new Range('G', 'K')
        );

        [Fact]
        public void AddWhenAddedPatternFitsStringShouldAddPatternAndMatchReturnTrueAndRemainingText()
        {
            Choice hexadecimal = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            IMatch intialResult = hexadecimal.Match("g8");
            
            Assert.False(intialResult.Success());
            Assert.Equal("g8", intialResult.RemainingText());

            hexadecimal.Add(someLetters);

            IMatch resultAfterAdd = hexadecimal.Match("g8");

            Assert.True(resultAfterAdd.Success());
            Assert.Equal("8", resultAfterAdd.RemainingText());
        }

        [Fact]
        public void AddWhenAddedPatternDoNotFitsStringShouldAddPatternAndMatchReturnFalseAndText()
        {
            Choice hexadecimal = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            IMatch intialResult = hexadecimal.Match("p8");

            Assert.False(intialResult.Success());
            Assert.Equal("p8", intialResult.RemainingText());

            hexadecimal.Add(someLetters);

            IMatch resultAfterAdd = hexadecimal.Match("p8");

            Assert.False(resultAfterAdd.Success());
            Assert.Equal("p8", resultAfterAdd.RemainingText());
        }

        [Fact]
        public void AddWhenNullShouldAddNothingAndMatchReturnFalseAndText()
        {
            Choice hexadecimal = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
            );

            IMatch intialResult = hexadecimal.Match("p8");

            Assert.False(intialResult.Success());
            Assert.Equal("p8", intialResult.RemainingText());

            hexadecimal.Add(null);

            IMatch resultAfterAdd = hexadecimal.Match("p8");

            Assert.False(resultAfterAdd.Success());
            Assert.Equal("p8", resultAfterAdd.RemainingText());
        }
    }
}