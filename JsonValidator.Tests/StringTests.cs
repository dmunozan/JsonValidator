using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class StringTests
    {
        [Fact]
        public void MatchWhenTwoDoubleQuotesShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new String().Match("\"\"");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenOneDoubleQuoteShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new String().Match("\"");

            Assert.False(obtainedResult.Success());
            Assert.Equal("\"", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenTextWrappedInDoubleQuotesShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new String().Match("\"anyText\"");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNotAllowedCharactersWrappedInDoubleQuotesShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new String().Match("\"any\"Text\"");

            Assert.True(obtainedResult.Success());
            Assert.Equal("Text\"", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenBackslashAndEscapableCharacterWrappedInDoubleQuotesShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new String().Match("\"\\n\"");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenMultipleBackslashAndEscapableCharacterWrappedInDoubleQuotesShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new String().Match("\"\\n\\f\"");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenBackslashAndNonEscapableCharacterWrappedInDoubleQuotesShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new String().Match("\"\\n\\g\"");

            Assert.False(obtainedResult.Success());
            Assert.Equal("\"\\n\\g\"", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenBackslashAndValidUnicodeCharacterWrappedInDoubleQuotesShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new String().Match("\"\\u0a2F\"");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenBackslashAndNonValidUnicodeCharacterWrappedInDoubleQuotesShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new String().Match("\"\\uPa2F\"");

            Assert.False(obtainedResult.Success());
            Assert.Equal("\"\\uPa2F\"", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Number().Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
