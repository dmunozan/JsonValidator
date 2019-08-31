using System;

namespace JsonValidator
{
    public class Value
    {
        readonly IPattern pattern;

        public Value()
        {
            this.pattern = new Text("null");
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
