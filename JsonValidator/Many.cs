using System;

namespace JsonValidator
{
    public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch patternMatch = pattern.Match(text);

            while (patternMatch.Success())
            {
                patternMatch = pattern.Match(patternMatch.RemainingText());
            }

            return new Match(true, patternMatch.RemainingText());
        }
    }
}
