using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class AnyTests
    {
        [Fact]
        public void MatchWhenStartsWithFirstCharacterShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Any("eE").Match("ea");

            Assert.True(obtainedResult.Success());
            Assert.Equal("a", obtainedResult.RemainingText());
        }
    }
}
