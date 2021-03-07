using System;
using System.Collections.Generic;
using System.Text;

namespace SinavProje.Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
