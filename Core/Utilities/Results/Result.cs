using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
       

        public Result(bool success, string message):this(success) 
        {                               //this ile tek parametreli olan const çalıştır demek.
          Message = message;
          Success = success;
        }
        //belki başarılı dicem ama mesaj göndermicem?
        public Result(bool success) 
        {
            Success = success;
        }
        

        public bool Success { get; }

        public string Message { get; }
    }
}
