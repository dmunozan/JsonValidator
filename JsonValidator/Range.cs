using System;

namespace JsonValidator
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            bool isInRange = this.start <= text[0] && text[0] <= this.end;

            return isInRange ? new Match(isInRange, text.Substring(1)) : new Match(isInRange, text);
        }
    }
}
