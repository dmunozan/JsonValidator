﻿using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ManyTests
    {
        [Fact]
        public void MatchWhenStartsWithOneOccurrenceShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Many(new Character('a')).Match("abc");

            Assert.True(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithMoreThanOneOccurrenceShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Many(new Character('a')).Match("aaaabc");

            Assert.True(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }
    }
}
