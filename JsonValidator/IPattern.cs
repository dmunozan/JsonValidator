using System;

namespace JsonValidator
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
