using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Extensions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Utils;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class UpdateApplicationPoolHandler : ICommandHandler<UpdateApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public UpdateApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }

        public void Handle(UpdateApplicationPool command)
        {
            command.ThrowIfNull(GetType().Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            applicationPool.ThrowIfNull(command.Name);
            var newApplicationPool = _applicationPoolFacade.GetApplicationPool(command.NewName);
            newApplicationPool.ThrowIfExists();
            applicationPool.Name = command.NewName;
            applicationPool.ManagedPipelineMode =
                ApplicationPoolUtils.ParseToEnumOrThrow<ManagedPipelineMode>(command.ManagedPipelineMode);
            applicationPool.ManagedRuntimeVersion = command.ManagedRuntimeVersion;
            applicationPool.ProcessModel.IdentityType =
                ApplicationPoolUtils.ParseToEnumOrThrow<ProcessModelIdentityType>(command.Identity);
            _applicationPoolFacade.UpdateApplicationPool();
        }
    }
}