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
            var attribute = invocation.GetAttribute<Measure>();
            if (attribute == null)
            {
                return;
            }

            var metricName = attribute.GetValue(nameof(Measure.MetricName));

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            invocation.Proceed();
            var returnValue = (Task)invocation.ReturnValue;

            returnValue.ContinueWith(t =>
            {
                stopwatch.Stop();
                Console.WriteLine($"{metricName}: {stopwatch.ElapsedMilliseconds}");
            });
        }
    }
}
