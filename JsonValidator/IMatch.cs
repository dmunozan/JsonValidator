using System;

namespace JsonValidator
{
    public interface IMatch
    {
        bool Success();

        string RemainingText();
    }
}
