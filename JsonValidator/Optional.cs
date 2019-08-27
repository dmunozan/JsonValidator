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
            IMatch patternMatch = pattern.Match(text);

            return new Match(true, patternMatch.RemainingText());
        }
    }
}
