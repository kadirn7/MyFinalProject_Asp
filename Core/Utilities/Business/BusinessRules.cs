using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
         public static IResult Run(params IResult[] logics) //istediğimiz kadar IResult u parametre olarak geçebiliyoruz bu yapı sayesinde.
        {
            
            foreach(var logic in logics)
            {
                if (!logic.Success) 
                {
                    return logic; //başarısız olanı business'a haber ediyoruz.
                }
            }
            return null;

        }
        /*  //alternatif yazım
        public static List<IResult> Run(params IResult[] logics)
        {
            List<IResult> errorResults = new List<IResult>();
            foreach(var logic in logics)
            {
                if(!logic.Success)
                {
                    errorresults.Add(logic);
                }
            }
            return errorResults;
        }
        */

    }
}
