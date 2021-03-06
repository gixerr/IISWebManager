﻿using Autofac;
using IISWebManager.Api.IoC.Modules;

namespace IISWebManager.Api.IoC.Providers
{
    public class ModulesProvider : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<QueryModule>();
            builder.RegisterModule<FacadeModule>();
            builder.RegisterModule<FactoryModule>();
            builder.RegisterModule<SettingsModule>();
            builder.RegisterModule<ExceptionModule>();
        }
    }

}