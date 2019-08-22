using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void MatchWhenNullShouldReturnFalse()
        {
            Assert.False(new Character('a').Match(null));
        }

        [Fact]
        public void MatchWhenEmptyShouldReturnFalse()
        {
            Assert.False(new Character('a').Match(""));
        }

        [Fact]
        public void MatchWhenFirstCharFromTextMatchesShouldReturnTrue()
        {
            Assert.True(new Character('a').Match("all right"));
        }

        [Fact]
        public void MatchWhenFirstCharFromTextDoNotMatchesShouldReturnFalse()
        {
            Assert.False(new Character('a').Match("wrong"));
        }
    }
}
