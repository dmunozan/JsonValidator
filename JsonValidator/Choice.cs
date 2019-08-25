using System;

namespace JsonValidator
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                IMatch currentPatternMatch = pattern.Match(text);

                if (currentPatternMatch.Success())
                {
                    return currentPatternMatch;
                }
            }

            return new Match(false, text);
        }
    }
}
