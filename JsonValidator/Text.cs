using System;

namespace JsonValidator
{
    public class PrefixText
    {
        readonly string prefix;

        public PrefixText(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (prefix == text)
            {
                return new Match(true, "");
            }

            return new Match(false, text);
        }
    }
}
