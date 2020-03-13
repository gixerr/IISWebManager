using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Extensions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.ApplicationPools;

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
            command.ThrowIfNull(command.Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            applicationPool.ThrowIfNull(command.Name);
            
            _applicationPoolFacade.DeleteApplicationPool(applicationPool);
        }
    }
}