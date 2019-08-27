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
    }
}
