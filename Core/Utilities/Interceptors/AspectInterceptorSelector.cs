using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Linq;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //   classAttributes.Add(new ExceptionLogAspect(typeof(Filelogger))); //Otomatik olarak sistemmdeki bütün methodları log'a  dahil etmeye yarıyor

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //öncelik değerine göre sıralama yapılır.
        }
    }
     
     
}
