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
            Match expectedResult = new Match(false, "");
            Match obtainedResult = (Match)new Character('a').Match("");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenFirstCharFromTextMatchesShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "ll right");
            Match obtainedResult = (Match)new Character('a').Match("all right");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenFirstCharFromTextDoNotMatchesShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "wrong");
            Match obtainedResult = (Match)new Character('a').Match("wrong");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }
    }
}
