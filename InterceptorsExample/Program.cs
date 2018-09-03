using Autofac;
using System;
using System.Threading.Tasks;

namespace InterceptorsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.Build();

            //var processor = container.Resolve<IProcessor>();
            //processor.Process();

            var processorAsync = container.Resolve<IProcessorAsync>();
            Task.Run(async () =>
            {
                await processorAsync.Process();
            });

            Console.ReadKey();
        }
    }
}
