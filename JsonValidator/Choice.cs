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
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            foreach (var pattern in patterns)
            {
                Match currentPatternMatch = (Match)pattern.Match(text);
                if (currentPatternMatch.Success())
                {
                    return new Match(true, currentPatternMatch.RemainingText());
                }
            }

            return new Match(false, text);
        }
    }
}
