using System;

namespace JsonValidator
{
    public class Value
    {
        readonly IPattern pattern;

        public Value()
        {
            Choice value = new Choice(
                new String(),
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null"));

            Many whitespace = new Many(new Any(" \r\n\t"));
            Sequence separator = new Sequence(whitespace, new Character(','), whitespace);

            List elements = new List(value, separator);

            Sequence arrayValue = new Sequence(new Character('['), whitespace, new Optional(elements), whitespace, new Character(']'));

            Sequence member = new Sequence(new String(), whitespace, new Character(':'), whitespace, value);
            List members = new List(member, separator);

            Sequence objectValue = new Sequence(new Character('{'), whitespace, members, whitespace, new Character('}'));

            value.Add(arrayValue);
            value.Add(objectValue);

            this.pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
