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
            Console.WriteLine(accepted);
            if (text == null)
            {
                return new Match(false, text);
            }

            if (text[1] == 'e')
            {
                return new Match(true, "e");
            }

            return new Match(true, "a");
        }
    }
}
