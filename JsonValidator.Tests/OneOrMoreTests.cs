using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class OneOrMoreTests
    {
        [Fact]
        public void MatchWhenAllCharactersFitThePatternShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new OneOrMore(new Range('0', '9')).Match("123");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithPatternShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new OneOrMore(new Range('0', '9')).Match("1a");

            Assert.True(obtainedResult.Success());
            Assert.Equal("a", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNoStartsWithPatternShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new OneOrMore(new Range('0', '9')).Match("bc");

            Assert.False(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new OneOrMore(new Range('0', '9')).Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new OneOrMore(new Range('0', '9')).Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
