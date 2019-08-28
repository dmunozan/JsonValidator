using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class NumberTests
    {
        [Fact]
        public void MatchWhenOneNumberShouldReturnTrueAndEmptyString()
        {
            IMatch obtainedResult = new Number().Match("2");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }
    }
}
