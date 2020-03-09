using Autofac;
using IISWebManager.Infrastructure.Dispatchers.Query;
using IISWebManager.Infrastructure.Handlers;
using IISWebManager.Infrastructure.Handlers.Query;

namespace IISWebManager.Api.IoC.Modules
{
    public class QueryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(IQueryDispatcher).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryDispatcher>()
                .As<IQueryDispatcher>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }

    }
}