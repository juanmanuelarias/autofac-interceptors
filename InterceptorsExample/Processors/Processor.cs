using Autofac.Extras.DynamicProxy;
using InterceptorsExample.Interceptors;
using System;
using System.Threading;

namespace InterceptorsExample
{
    [Intercept(typeof(Logger))]
    [Intercept(typeof(Measurable))]
    public class Processor : IProcessor
    {
        [Measure(MetricName = Metrics.TimeToExecute)]
        public void Process()
        {
            Thread.Sleep(1234);
            Console.WriteLine("Execution");
        }
    }

    public class Metrics
    {
        public const string TimeToExecute = "InterceptorsExample.Process.TimeToExecute";
    }
}
