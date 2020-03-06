using Autofac;
using IISWebManager.Api.IoC.Modules;

namespace IISWebManager.Api.IoC.Builders
{
    public class ModulesProvider : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<QueryModule>();
            builder.RegisterModule<FacadeModule>();
        }
    }

}