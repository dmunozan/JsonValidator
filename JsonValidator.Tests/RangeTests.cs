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
            Match expectedResult = new Match(true, "ab");
            Match obtainedResult = (Match)new Range('a', 'f').Match("fab");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenCharOnRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "cd");
            Match obtainedResult = (Match)new Range('a', 'f').Match("bcd");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenCharOutOfRangeShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "1ab");
            Match obtainedResult = (Match)new Range('a', 'f').Match("1ab");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }
    }
}
