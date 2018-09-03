using Castle.DynamicProxy;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InterceptorsExample.Interceptors
{
    public class MeasurableAsync : IInterceptor
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
            var returnValue = (Task)invocation.ReturnValue;

            returnValue.ContinueWith(t =>
            {
                stopwatch.Stop();
                Console.WriteLine($"Took: {stopwatch.ElapsedMilliseconds}");
            });
        }
    }
}
