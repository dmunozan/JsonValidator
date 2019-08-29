﻿using System;
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
    }
}
