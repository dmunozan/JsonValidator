using System;

namespace JsonValidator
{
    public class Any
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            Console.WriteLine(accepted + text);
            return new Match(true, "a");
        }
    }
}
