using Autofac;
using IISWebManager.Application.Exceptions;

namespace IISWebManager.Api.IoC.Modules
{
    public class ExceptionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExceptionToResponseMapper>()
                .As<IExceptionToResponseMapper>()
                .InstancePerLifetimeScope();
        }
    }
}