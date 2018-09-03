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
        [Measure]
        public void Process()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Execution");
        }
    }
}
