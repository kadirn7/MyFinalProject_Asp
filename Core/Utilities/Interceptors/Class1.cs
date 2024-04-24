using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

using System.Reflection;
using System.Linq;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected  virtual void OnBefore (IInvocation invocation) { }
        protected virtual void  OnAfter (IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore (invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally 
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter (invocation);
        }

    }
    
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
