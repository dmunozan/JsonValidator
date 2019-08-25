using System;

namespace JsonValidator
{
    public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string remainingText = text;

            foreach (var pattern in patterns)
            {
                IMatch currentPatternMatch = pattern.Match(remainingText);

                if (!currentPatternMatch.Success())
                {
                    return new Match(false, text);
                }

                remainingText = currentPatternMatch.RemainingText();
            }

            return new Match(true, remainingText);
        }
    }
}
