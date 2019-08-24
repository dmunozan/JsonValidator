﻿using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class RangeTests
    {
        [Fact]
        public void MatchWhenNullShouldReturnFalseAndNull()
        {
            Match expectedResult = new Match(false, null);
            Match obtainedResult = (Match)new Range('a', 'z').Match(null);
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenEmptyShouldReturnFalseAndEmptyString()
        {
            Match expectedResult = new Match(false, "");
            Match obtainedResult = (Match)new Range('a', 'z').Match("");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenFirstCharOfRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "bc");
            Match obtainedResult = (Match)new Range('a', 'f').Match("abc");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenLastCharOfRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "ab");
            Match obtainedResult = (Match)new Range('a', 'f').Match("fab");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenCharOnRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "cd");
            Match obtainedResult = (Match)new Range('a', 'f').Match("bcd");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
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