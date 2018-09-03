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

            builder.RegisterType<Processor>()
                .As<IProcessor>()
                .EnableInterfaceInterceptors();

            // Register interceptors
            builder.Register(c => new Logger());
            builder.Register(c => new Measurable());

            return builder.Build();
        }
    }
}
