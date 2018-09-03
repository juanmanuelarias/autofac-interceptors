using Castle.DynamicProxy;
using System;

namespace InterceptorsExample.Interceptors
{
    public class Logger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Start");
            invocation.Proceed();
            Console.WriteLine("Finish");
        }
    }
}
