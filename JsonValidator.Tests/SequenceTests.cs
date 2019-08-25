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
            IMatch obtainedResult = ab.Match("def");

            Assert.False(obtainedResult.Success());
            Assert.Equal("def", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenABEmptyStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = ab.Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenABNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = ab.Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }

        static Sequence abc = new Sequence(
            ab,
            new Character('c')
        );

        [Fact]
        public void MatchWhenStartsWithABCShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = abc.Match("abcd");

            Assert.True(obtainedResult.Success());
            Assert.Equal("d", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNoStartsWithABCShouldReturnFalseAndText()
        {
            IMatch obtainedResult = abc.Match("def");

            Assert.False(obtainedResult.Success());
            Assert.Equal("def", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithABButNotCShouldReturnFalseAndText()
        {
            IMatch obtainedResult = abc.Match("abx");

            Assert.False(obtainedResult.Success());
            Assert.Equal("abx", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenABCEmptyStringShouldReturnFalseAndText()
        {
            IMatch obtainedResult = abc.Match("");

            Assert.False(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenABCNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = abc.Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
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
            IMatch obtainedResult = hexSeq.Match("u1234");

            Assert.True(obtainedResult.Success());
            Assert.Equal("", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithHexSeqShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hexSeq.Match("uabcdef");

            Assert.True(obtainedResult.Success());
            Assert.Equal("ef", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenStartsWithHexSeqAndSpacePlusCharactersShouldReturnTrueAndRemainingText()
        {
            IMatch obtainedResult = hexSeq.Match("uB005 ab");

            Assert.True(obtainedResult.Success());
            Assert.Equal(" ab", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenNoStartsWithHexSeqShouldReturnFalseAndText()
        {
            IMatch obtainedResult = hexSeq.Match("abc");

            Assert.False(obtainedResult.Success());
            Assert.Equal("abc", obtainedResult.RemainingText());
        }

        [Fact]
        public void MatchWhenHexSeqNullShouldReturnFalseAndText()
        {
            IMatch obtainedResult = hexSeq.Match(null);

            Assert.False(obtainedResult.Success());
            Assert.Null(obtainedResult.RemainingText());
        }
    }
}
