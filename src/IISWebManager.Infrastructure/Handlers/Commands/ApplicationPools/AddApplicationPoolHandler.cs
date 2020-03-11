using System;
using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Exceptions;
using IISWebManager.Infrastructure.Facades;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Handlers.Commands
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
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            if (applicationPool is {})
            {
                throw new ApplicationPoolAlreadyExistsException(command.Name);
            }

            var managedPipelineMode = Enum.TryParse(command.ManagedPipelineMode, out ManagedPipelineMode mode)
                ? mode
                : throw new InvalidManagedPipelineModeException(command.ManagedPipelineMode);
            
            _applicationPoolFacade.AddApplicationPool(command.Name, managedPipelineMode,
                command.ManagedRuntimeVersion, command.AutoStart);
        }
    }
}