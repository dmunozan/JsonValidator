using System;

namespace JsonValidator
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return text?.StartsWith(prefix) == true ? new Match(true, text.Substring(prefix.Length)) : new JsonValidator.Match(false, text);
        }
    }
}
