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
            if (text == null)
            {
                return new Match(false, text);
            }

            return text.StartsWith(prefix) ? new Match(true, text.Substring(prefix.Length)) : new JsonValidator.Match(false, text);
        }
    }
}
