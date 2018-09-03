using Castle.DynamicProxy;
using System;
using System.Diagnostics;
using System.Linq;

namespace InterceptorsExample.Interceptors
{
    public class Measurable : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!invocation
                .MethodInvocationTarget
                .CustomAttributes
                .Any(a => a.AttributeType == typeof(Measure)))
            {
                return;
            }

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            Console.WriteLine($"Took: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
