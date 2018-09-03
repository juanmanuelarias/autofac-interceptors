using Autofac;
using Autofac.Extras.DynamicProxy;
using InterceptorsExample.Interceptors;

namespace InterceptorsExample
{
    public class Container
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            // Register Processors
            builder.RegisterType<Processor>()
                .As<IProcessor>()
                .EnableInterfaceInterceptors();

            builder.RegisterType<ProcessorAsync>()
                 .As<IProcessorAsync>()
                 .EnableInterfaceInterceptors();

            // Register interceptors
            builder.Register(c => new Logger());
            builder.Register(c => new Measurable());
            builder.Register(c => new MeasurableAsync());

            return builder.Build();
        }
    }
}
