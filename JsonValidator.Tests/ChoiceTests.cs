﻿using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ChoiceTests
    {
        static Choice digit = new Choice(
                new Character('0'),
                new Range('1', '9')
        );

        [Fact]
        public void MatchWhenStartsWithDigitCharacterShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = digit.Match("012");
            
            Assert.True(obtainedResult.Success());
            Assert.Equal("12", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfDigitRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "2");
            Match obtainedResult = (Match)digit.Match("12");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfDigitRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "2");
            Match obtainedResult = (Match)digit.Match("92");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfDigitRangeAndNotDigitCharacterShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "a9");
            Match obtainedResult = (Match)digit.Match("a9");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenEmptyOnDigitShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "");
            Match obtainedResult = (Match)digit.Match("");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenNullOnDigitShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, null);
            Match obtainedResult = (Match)digit.Match(null);
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        static Choice hex = new Choice(
                digit,
                new Choice(
                    new Range('a', 'f'),
                    new Range('A', 'F')
                )
        );

        [Fact]
        public void MatchWhenStartsWithHexDigitCharacterShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "12");
            Match obtainedResult = (Match)hex.Match("012");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfHexDigitRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "2");
            Match obtainedResult = (Match)hex.Match("12");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfHexDigitRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "2");
            Match obtainedResult = (Match)hex.Match("92");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfFirstHexRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "9");
            Match obtainedResult = (Match)hex.Match("a9");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfFirstHexRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "8");
            Match obtainedResult = (Match)hex.Match("f8");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithFirstCharOfSecondHexRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "9");
            Match obtainedResult = (Match)hex.Match("A9");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithLastCharOfSecondHexRangeShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "8");
            Match obtainedResult = (Match)hex.Match("F8");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfFirstHexRangeAndNotSecondHexRangeDigitCharacterOrDigitRangeShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "g8");
            Match obtainedResult = (Match)hex.Match("g8");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithCharOutOfSecondHexRangeAndNotFirstHexRangeDigitCharacterOrDigitRangeShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "G8");
            Match obtainedResult = (Match)hex.Match("G8");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenEmptyOnHexShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "");
            Match obtainedResult = (Match)hex.Match("");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenNullOnHexShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, null);
            Match obtainedResult = (Match)hex.Match(null);
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }
    }
}