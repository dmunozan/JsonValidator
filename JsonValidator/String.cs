﻿using System;

namespace JsonValidator
{
    public class String : IPattern
    {
        readonly IPattern pattern;

        public String()
        {
            const char LastCharacter = (char)ushort.MaxValue;
            Any spaceExclamation = new Any(" !");
            Range hashtagToLeftSquareBracket = new Range('#', '[');
            Range rightSquareBracketToLastCharacter = new Range(']', LastCharacter);
            Choice character = new Choice(spaceExclamation, hashtagToLeftSquareBracket, rightSquareBracketToLastCharacter);
            Many characters = new Many(character);

            this.pattern = new Sequence(new Character('"'), characters, new Character('"'));
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
