﻿using System;
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

        [Fact]
        public void MatchWhenStartsWithLastCharacterShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Any("aA").Match("Ae");

            Assert.True(obtainedResult.Success());
            Assert.Equal("e", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNoStartsWithAnyAcceptedCharacterShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Any("eE").Match("a");

            Assert.False(obtainedResult.Success());
            Assert.Equal("a", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Any("eE").Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = new Any("eE").Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
