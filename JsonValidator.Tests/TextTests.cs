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

        [Fact]
        public void MatchWhenNoStartsWithStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Text("true").Match("false");

            Assert.False(obtainedResult.Success());
            Assert.Equal("false", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Text("true").Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Text("true").Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }

        //Check for special empty string cases
        [Fact]
        public void MatchWhenEmptyStringAndNotNullShouldReturnTrueAndText()
        {
            IMatch obtainedResult = new Text("").Match("true");

            Assert.True(obtainedResult.Success());
            Assert.Equal("true", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringAndNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Text("").Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
