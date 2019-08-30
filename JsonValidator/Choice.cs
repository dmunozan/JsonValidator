using System;

namespace JsonValidator
{
    public class Choice : IPattern
    {
        IPattern[] patterns;

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

        public void Add(IPattern pattern)
        {
            int currentPatternCount = this.patterns.Length;

            IPattern[] newPatternArray = new IPattern[currentPatternCount + 1];
            patterns.CopyTo(newPatternArray, 0);
            newPatternArray[currentPatternCount] = pattern;

            this.patterns = newPatternArray;
        }
    }
}
