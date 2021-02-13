using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Core.Utilities.Result
{
    //Personel, List<User>, Customer, List<Product> Entity ile throw exception vb. şeylerde atabilir
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
