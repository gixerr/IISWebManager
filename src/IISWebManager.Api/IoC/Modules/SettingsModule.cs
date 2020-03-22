using Autofac;
using IISWebManager.Api.Extensions;
using IISWebManager.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace IISWebManager.Api.IoC.Modules
{
    public class SettingsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => c.Resolve<IConfiguration>()
                    .BindSettings<BuildSettings>("buildSettings"))
                .SingleInstance();
        }
    }
}