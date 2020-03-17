using Autofac;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;

namespace IISWebManager.Api.IoC.Modules
{
    public class FacadeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiteFacade>()
                .As<ISiteFacade>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<ApplicationPoolFacade>()
                .As<IApplicationPoolFacade>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationFacade>()
                .As<IApplicationFacade>()
                .InstancePerLifetimeScope();
        }
    }
}