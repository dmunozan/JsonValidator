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

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return text[0] == this.pattern;
        }
    }
}
