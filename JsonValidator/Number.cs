using System;

namespace JsonValidator
{
    public class Number : IPattern
    {
        readonly IPattern pattern;

        public Number()
        {
            Range oneNine = new Range('1', '9');
            Choice digit = new Choice(new Character('0'), oneNine);
            OneOrMore digits = new OneOrMore(digit);
            Sequence integer = new Sequence(new Optional(new Character('-')), new Choice(new Sequence(oneNine, digits), digit));
            Sequence fraction = new Sequence(new Character('.'), digits);
            Any sign = new Any("-+");
            Sequence exponent = new Sequence(new Any("eE"), new Optional(sign), digits);

            this.pattern = new Sequence(integer, new Optional(fraction), new Optional(exponent));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
