using Autofac.Extras.DynamicProxy;
using InterceptorsExample.Interceptors;
using System;
using System.Threading.Tasks;

namespace InterceptorsExample
{
    [Intercept(typeof(MeasurableAsync))]
    public class ProcessorAsync : IProcessorAsync
    {
        [Measure(MetricName = Metrics.TimeToExecute)]
        public async Task Process()
        {
            await Task.Delay(1234);
            Console.WriteLine("Executed Async");
        }
    }
}
