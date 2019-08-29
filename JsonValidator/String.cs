using System;

namespace JsonValidator
{
    public class String : IPattern
    {
        readonly IPattern pattern;

        public String()
        {
            this.pattern = new Sequence(new Character('"'), new Character('"'));
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
