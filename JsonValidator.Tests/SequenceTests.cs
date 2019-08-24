using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class SequenceTests
    {
        static Sequence ab = new Sequence(
            new Character('a'),
            new Character('b')
        );

        [Fact]
        public void MatchWhenStartsWithABShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "cd");
            Match obtainedResult = (Match)ab.Match("abcd");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }
    }
}
