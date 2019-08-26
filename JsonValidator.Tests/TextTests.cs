using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class TextTests
    {
        [Fact]
        public void MatchWhenSameStringShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new Text("true").Match("true");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithStringPlusOtherCharactersShouldReturnTrueAndOtherCharacters()
        {
            IMatch obtainedResult = new Text("true").Match("trueX");

            Assert.True(obtainedResult.Success());
            Assert.Equal("X", obtainedResult.RemainingText());
        }
    }
}
