using Autofac;
using IISWebManager.Infrastructure.Factories;

namespace IISWebManager.Api.IoC.Modules
{
    public class FactoryModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BuildFactory>()
                .As<IBuildFactory>()
                .InstancePerLifetimeScope();
        }
    }
}