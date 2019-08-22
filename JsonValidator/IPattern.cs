using System;

namespace JsonValidator
{
    public interface IPattern
    {
        bool Match(string text);
    }
}
