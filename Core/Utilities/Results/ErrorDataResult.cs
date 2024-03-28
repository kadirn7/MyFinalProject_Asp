using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {//tüm bilgileri verdiği durum 

        }
        public ErrorDataResult(T data) : base(data, false)
        {//mesaj işlerine girmek istemediği zaman

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {//datayı default haliyle göndermek isterse.

        }
        public ErrorDataResult() : base(default, false)
        {//datayı default haliyle göndermek istiyor mesajda vermek istemiyorsa.Sadece başarılı demek için.


        }
    }
}
