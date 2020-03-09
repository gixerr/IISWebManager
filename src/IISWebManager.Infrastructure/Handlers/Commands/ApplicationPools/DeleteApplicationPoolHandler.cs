using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Exceptions;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class DeleteApplicationPoolHandler : ICommandHandler<DeleteApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public DeleteApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }
        public void Handle(DeleteApplicationPool command)
        {
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            if (applicationPool is null)
            {
                throw new ApplicationPoolNotExistsException(command.Name);
            }
            
            _applicationPoolFacade.DeleteApplicationPool(applicationPool);
        }
    }
}