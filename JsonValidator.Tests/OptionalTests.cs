using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class OptionalTests
    {
        [Fact]
        public void MatchWhenStartsWithOptionalPatternShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Optional(new Character('a')).Match("abc");

            Assert.True(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithMoreThanOneOccurrenceOfOptionalPatternShouldReturnTrueAndTextWithoutFirstOccurrence()
        {
            IMatch obtainedResult = new Optional(new Character('a')).Match("aabc");

            Assert.True(obtainedResult.Success());
            Assert.Equal("abc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNoStartsWithOptionalPatternShouldReturnTrueAndText()
        {
            IMatch obtainedResult = new Optional(new Character('a')).Match("bc");

            Assert.True(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringShouldReturnTrueAndText()
        {
            IMatch obtainedResult = new Optional(new Character('a')).Match("");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullShouldReturnTrueAndText()
        {
            IMatch obtainedResult = new Optional(new Character('a')).Match(null);

            Assert.True(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
