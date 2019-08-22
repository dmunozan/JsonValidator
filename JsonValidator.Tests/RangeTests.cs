using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class RangeTests
    {
        [Fact]
        public void MatchWhenNullShouldReturnFalse()
        {
            Assert.False(new Range('a', 'z').Match(null));
        }

        [Fact]
        public void MatchWhenEmptyShouldReturnFalse()
        {
            Assert.False(new Range('a', 'z').Match(""));
        }

        [Fact]
        public void MatchWhenFirstCharOfRangeShouldReturnTrue()
        {
            Assert.True(new Range('a', 'f').Match("abc"));
        }

        [Fact]
        public void MatchWhenLastCharOfRangeShouldReturnTrue()
        {
            Assert.True(new Range('a', 'f').Match("fab"));
        }

        [Fact]
        public void MatchWhenCharOnRangeShouldReturnTrue()
        {
            Assert.True(new Range('a', 'f').Match("bcd"));
        }

        [Fact]
        public void MatchWhenCharOutOfRangeShouldReturnFalse()
        {
            Assert.False(new Range('a', 'f').Match("1ab"));
        }
    }
}
