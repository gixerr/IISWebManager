using Autofac;
using IISWebManager.Infrastructure.Facades.ApplicationPools;

namespace IISWebManager.Api.IoC.Modules
{
    public class FacadeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationPoolFacade>()
                .As<IApplicationPoolFacade>()
                .InstancePerLifetimeScope();
        }
    }
}