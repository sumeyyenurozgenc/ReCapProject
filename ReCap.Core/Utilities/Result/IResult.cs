using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Core.Utilities.Result
{
    //Tüm voidler için kullanılacak başlangıç
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
