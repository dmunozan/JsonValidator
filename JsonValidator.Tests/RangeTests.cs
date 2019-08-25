﻿using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class RangeTests
    {
        [Fact]
        public void MatchWhenNullShouldReturnFalseAndNull()
        {
            IMatch obtainedResult = new Range('a', 'z').Match(null);
            
            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenEmptyShouldReturnFalseAndEmptyString()
        {
            IMatch obtainedResult = new Range('a', 'z').Match("");
            
            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenFirstCharOfRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Range('a', 'f').Match("abc");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("bc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenLastCharOfRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Range('a', 'f').Match("fab");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("ab", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenCharOnRangeShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = new Range('a', 'f').Match("bcd");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("cd", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenCharOutOfRangeShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "1ab");
            Match obtainedResult = (Match)new Range('a', 'f').Match("1ab");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }
    }
}
