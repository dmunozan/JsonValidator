﻿using System;

namespace JsonValidator
{
    public class Value
    {
        readonly IPattern pattern;

        public Value()
        {
            this.pattern = new Choice(
                new Number(),
                new Text("true"),
                new Text("false"),
                new Text("null"));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
