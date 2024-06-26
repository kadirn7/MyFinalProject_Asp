﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result,IDataResult<T>    
    {
        //burda :base(success,message) implemente ederek kodları bir daha yazmak zorunda kalmamızı sağlıyor
        //daha açık konuşmak gerekirse Result sınıfındaki public bool Success gibi fonksiyorunları tekrar yazmamızı sağlıyor.
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data; 
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
