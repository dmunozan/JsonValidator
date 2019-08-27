using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ListTests
    {
        [Fact]
        public void MatchWhenAllStringFitThePatternShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new List(new Range('0', '9'), new Character(',')).Match("1,2,3");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStringFitThePatternPlusSeparatorShouldReturnTrueAndSeparator()
        {
            IMatch obtainedResult = new List(new Range('0', '9'), new Character(',')).Match("1,2,3,");

            Assert.True(obtainedResult.Success());
            Assert.Equal(",", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartFitElementPlusOtherCharactersShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new List(new Range('0', '9'), new Character(',')).Match("1a");

            Assert.True(obtainedResult.Success());
            Assert.Equal("a", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNoStartFitElementShouldReturnTrueAndText()
        {
            IMatch obtainedResult = new List(new Range('0', '9'), new Character(',')).Match("abc");

            Assert.True(obtainedResult.Success());
            Assert.Equal("abc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringShouldReturnTrueAndText()
        {
            IMatch obtainedResult = new List(new Range('0', '9'), new Character(',')).Match("");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullShouldReturnTrueAndText()
        {
            IMatch obtainedResult = new List(new Range('0', '9'), new Character(',')).Match(null);

            Assert.True(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
