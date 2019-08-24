using System;

namespace JsonValidator
{
    public class Character : IPattern
    {
        private readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            return (text[0] == this.pattern) ? new Match(true, text.Substring(1)) : new Match(false, text);
        }
    }
}
