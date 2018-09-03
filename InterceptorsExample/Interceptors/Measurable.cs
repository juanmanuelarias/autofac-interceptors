using Castle.DynamicProxy;
using System;
using System.Diagnostics;

namespace InterceptorsExample.Interceptors
{
    public class Measurable : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var attribute = invocation.GetAttribute<Measure>();
            if (attribute == null)
            {
                return;
            }

            var metricName = attribute.GetValue(nameof(Measure.MetricName));

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            Console.WriteLine($"{metricName}: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
