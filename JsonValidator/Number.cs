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
            Sequence integer = new Sequence(new Optional(new Character('-')), new Choice(new Sequence(oneNine, digits), digit));
            Optional fraction = new Optional(new Sequence(new Character('.'), digits));

            this.pattern = new Sequence(integer, fraction);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
