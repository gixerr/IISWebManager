using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Exceptions;
using IISWebManager.Infrastructure.Facades;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Handlers.Commands
{
    public class StartApplicationPoolHandler : ICommandHandler<StartApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public StartApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }
        public void Handle(StartApplicationPool command)
        {
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            if (applicationPool is null)
            {
                throw new ApplicationPoolNotExistsException(command.Name);
            }

            if (applicationPool.State == ObjectState.Started)
            {
                throw new ApplicationPoolAlreadyStarted(command.Name);
            }
            
            _applicationPoolFacade.StartApplicationPool(applicationPool);
        }
    }
}