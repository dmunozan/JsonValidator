using System;

namespace JsonValidator
{
    public class Text
    {
        readonly string prefix;

        public Text(string prefix)
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
