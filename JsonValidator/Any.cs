using System;

namespace JsonValidator
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            foreach (char character in accepted)
            {
                IMatch currentCharacterMatch = new Character(character).Match(text);

                if (currentCharacterMatch.Success())
                {
                    return currentCharacterMatch;
                }
            }

            return new Match(false, text);
        }
    }
}
