using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class SequenceTests
    {
        static Sequence ab = new Sequence(
            new Character('a'),
            new Character('b')
        );

        [Fact]
        public void MatchWhenStartsWithABShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = ab.Match("abcd");

            Assert.True(obtainedResult.Success());
            Assert.Equal("cd", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithAButNotBShouldReturnFalseAndText()
        {
            IMatch obtainedResult = ab.Match("ax");

            Assert.False(obtainedResult.Success());
            Assert.Equal("ax", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNoStartsWithABShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "def");
            Match obtainedResult = (Match)ab.Match("def");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenABEmptyStringShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "");
            Match obtainedResult = (Match)ab.Match("");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenABNullShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, null);
            Match obtainedResult = (Match)ab.Match(null);
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        static Sequence abc = new Sequence(
            ab,
            new Character('c')
        );

        [Fact]
        public void MatchWhenStartsWithABCShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "d");
            Match obtainedResult = (Match)abc.Match("abcd");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenNoStartsWithABCShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "def");
            Match obtainedResult = (Match)abc.Match("def");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithABButNotCShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "abx");
            Match obtainedResult = (Match)abc.Match("abx");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenABCEmptyStringShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "");
            Match obtainedResult = (Match)abc.Match("");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenABCNullShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, null);
            Match obtainedResult = (Match)abc.Match(null);
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        static Choice hex = new Choice(
            new Range('0', '9'),
            new Range('a', 'f'),
            new Range('A', 'F')
        );

        static Sequence hexSeq = new Sequence(
            new Character('u'),
            new Sequence(
                hex,
                hex,
                hex,
                hex
            )
        );

        [Fact]
        public void MatchWhenIsHexSeqShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "");
            Match obtainedResult = (Match)hexSeq.Match("u1234");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithHexSeqShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, "ef");
            Match obtainedResult = (Match)hexSeq.Match("uabcdef");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenStartsWithHexSeqAndSpacePlusCharactersShouldReturnTrueAndRemainingText()
        {
            Match expectedResult = new Match(true, " ab");
            Match obtainedResult = (Match)hexSeq.Match("uB005 ab");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenNoStartsWithHexSeqShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, "abc");
            Match obtainedResult = (Match)hexSeq.Match("abc");
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }

        [Fact]
        public void MatchWhenHexSeqNullShouldReturnFalseAndText()
        {
            Match expectedResult = new Match(false, null);
            Match obtainedResult = (Match)hexSeq.Match(null);
            string expectedResultString = expectedResult.Success() + ", " + expectedResult.RemainingText();
            string obtainedResultString = obtainedResult.Success() + ", " + obtainedResult.RemainingText();

            Assert.Equal(expectedResultString, obtainedResultString);
        }
    }
}
