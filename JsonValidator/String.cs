using System;

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

            Choice hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            Any otherEscapableCharacter = new Any("\"\\/bfnrt");
            Sequence unicodeCharacter = new Sequence(new Character('u'), hex, hex, hex, hex);
            Choice escapableCharacters = new Choice(otherEscapableCharacter, unicodeCharacter);
            Sequence backslashAndEscapableCharacter = new Sequence(new Character('\\'), escapableCharacters);

            Choice character = new Choice(spaceExclamation, hashtagToLeftSquareBracket, rightSquareBracketToLastCharacter, backslashAndEscapableCharacter);
            Many characters = new Many(character);

            this.pattern = new Sequence(new Character('"'), characters, new Character('"'));
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
