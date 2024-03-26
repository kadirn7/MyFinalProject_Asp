using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //IData result'un kullanılması sebebi normalde data şeklinde verilen 
        //<List<Product>> GetAll(); implementasyonunu aynı zamanda mesaj verebilir hale getirmek için kullanıyoruz.
        // Mesaj kısmı ise IResult tan implement edilerek geliyordu zaten orda bool Success { get; } gibi fonk var...
        T Data { get; }
    }
}
