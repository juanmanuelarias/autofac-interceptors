using Autofac;
using System;

namespace InterceptorsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.Build();

            var processor = container.Resolve<IProcessor>();

            processor.Process();

            Console.ReadKey();
        }
    }
}
