using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ValueTests
    {
        [Fact]
        public void MatchWhenNullTextShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("null");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenTrueTextShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("true");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenFalseTextShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("false");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNumberShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("-2.58e+058");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStringShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("\"string with\\nescapable\\fcharacters\\u1a9f\"");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyArrayShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("[]");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenArrayWithWhiteSpacesShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("[ \r\n\t]");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenArrayInsideArrayWithWhiteSpacesShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Value().Match("[ \r[ ]\n\t]");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }
    }
}
