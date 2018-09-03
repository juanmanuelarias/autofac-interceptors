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

            var processor = container.Resolve<IProcessorAsync>();

            Task.Run(async () =>
            {
                await processor.Process();
            });

            Console.ReadKey();
        }
    }
}
