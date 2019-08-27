using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class OneOrMoreTests
    {
        [Fact]
        public void MatchWhenAllCharactersFitThePatternShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new OneOrMore(new Range('0', '9')).Match("123");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }
    }
}
