using Autofac;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Facades.Applications;

namespace IISWebManager.Api.IoC.Modules
{
    public class FacadeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationPoolFacade>()
                .As<IApplicationPoolFacade>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationFacade>()
                .As<IApplicationFacade>()
                .InstancePerLifetimeScope();
        }
    }
}