using System;

namespace JsonValidator
{
    public class Number
    {
        readonly IPattern pattern;

        public Number()
        {
            this.pattern = new OneOrMore(new Range('0', '9'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
