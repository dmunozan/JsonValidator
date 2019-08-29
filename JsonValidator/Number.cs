using System;

namespace JsonValidator
{
    public class Number
    {
        readonly IPattern pattern;

        public Number()
        {
            Range oneNine = new Range('1', '9');
            Choice digit = new Choice(new Character('0'), oneNine);
            OneOrMore digits = new OneOrMore(digit);
            this.pattern = new Sequence(new Optional(new Character('-')), new Choice(new Sequence(oneNine, digits), digit));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
