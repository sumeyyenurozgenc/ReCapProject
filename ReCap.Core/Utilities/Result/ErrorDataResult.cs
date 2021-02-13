using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //Çok az kullanacağımız bir versiyon --> datayı default hali ile döndürme : alternatif kullanım
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        //Çok az kullanacağımız bir versiyon --> datayı default hali ile döndürme : alternatif kullanımı
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
