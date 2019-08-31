using System;

namespace JsonValidator
{
    public class Value
    {
        readonly IPattern pattern;

        public Value()
        {
            this.pattern = new Choice(
                new Text("null"),
                new Text("true"),
                new Text("false"));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
