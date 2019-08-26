using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ManyTests
    {
        [Fact]
        public void MatchWhenOneOcurrenceShouldReturnTrueAndRemaningText()
        {
            IMatch obtainedResult = new Many(new Character('a')).Match("abc");

            Assert.True(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }
    }
}
