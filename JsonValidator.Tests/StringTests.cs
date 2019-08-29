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
    }
}
