using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {//tüm bilgileri verdiği durum 
            
        }
        public SuccessDataResult(T data) : base(data, true)
        {//mesaj işlerine girmek istemediği zaman

        }
        public SuccessDataResult(string message) : base(default, true, message)
        {//datayı default haliyle göndermek isterse.

        }
        public SuccessDataResult() : base(default, true)
        {//datayı default haliyle göndermek istiyor mesajda vermek istemiyorsa.Sadece başarılı demek için.


        }
    }
}
