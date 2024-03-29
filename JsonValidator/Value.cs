﻿using System;

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

            Sequence arrayValue = new Sequence(whitespace, new Character('['), whitespace, elements, whitespace, new Character(']'), whitespace);

            Sequence member = new Sequence(new String(), whitespace, new Character(':'), whitespace, value);
            List members = new List(member, separator);

            Sequence objectValue = new Sequence(whitespace, new Character('{'), whitespace, members, whitespace, new Character('}'), whitespace);

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
