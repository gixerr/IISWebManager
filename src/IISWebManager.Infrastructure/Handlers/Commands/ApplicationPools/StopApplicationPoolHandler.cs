using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Exceptions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class StopApplicationPoolHandler : ICommandHandler<StopApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public StopApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }

        public void Handle(StopApplicationPool command)
        {
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            applicationPool.ThrowIfNull(command.Name);
            applicationPool.ThrowIfStopped();
            
            _applicationPoolFacade.StopApplicationPool(applicationPool);
        }
    }
}