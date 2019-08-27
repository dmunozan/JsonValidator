using System;

namespace JsonValidator
{
    public class Optional
    {
        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
