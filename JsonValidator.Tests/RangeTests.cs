using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class RangeTests
    {
        [Fact]
        public void MatchWhenNullShouldReturnFalseAndNull()
        {
            IMatch obtainedResult = new Range('a', 'z').Match(null);
            
            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyShouldReturnFalseAndEmptyString()
        {
            IMatch obtainedResult = new Range('a', 'z').Match("");
            
            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenFirstCharOfRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Range('a', 'f').Match("abc");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenLastCharOfRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Range('a', 'f').Match("fab");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("ab", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenCharOnRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Range('a', 'f').Match("bcd");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("cd", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenCharOutOfRangeShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Range('a', 'f').Match("1ab");
            
            Assert.False(obtainedResult.Success());
            Assert.Equal("1ab", obtainedResult.RemainingText());
        }
    }
}
