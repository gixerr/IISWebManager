using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Extensions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;
using IISWebManager.Infrastructure.Utils;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class AddApplicationPoolHandler : ICommandHandler<AddApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public AddApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }

        public void Handle(AddApplicationPool command)
        {
            command.ThrowIfNull(command.Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            applicationPool.ThrowIfExists();
            var managedPipelineMode =
                ApplicationPoolUtils.ParseToEnumOrThrow<ManagedPipelineMode>(command.ManagedPipelineMode);

            _applicationPoolFacade.AddApplicationPool(command.Name, managedPipelineMode,
                command.ManagedRuntimeVersion, command.AutoStart);
        }
    }
}