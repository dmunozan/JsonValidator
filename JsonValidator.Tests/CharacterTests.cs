using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void MatchWhenNullShouldReturnFalseAndNull()
        {
            IMatch obtainedResult = new Character('a').Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyShouldReturnFalseAndEmptyString()
        {
            IMatch obtainedResult = new Character('a').Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenFirstCharFromTextMatchesShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Character('a').Match("all right");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("ll right", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenFirstCharFromTextDoNotMatchesShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Character('a').Match("wrong");
            
            Assert.False(obtainedResult.Success());
            Assert.Equal("wrong", obtainedResult.RemainingText());
        }
    }
}
