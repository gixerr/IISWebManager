using IISWebManager.Application.Commands.ApplicationPools;
using IISWebManager.Application.Extensions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.ApplicationPools;

namespace IISWebManager.Infrastructure.Handlers.Commands.ApplicationPools
{
    public class RecycleApplicationPoolHandler : ICommandHandler<RecycleApplicationPool>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public RecycleApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }

        public void Handle(RecycleApplicationPool command)
        {
            command.ThrowIfNull(command.Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.Name);
            applicationPool.ThrowIfNull(command.Name);
            applicationPool.ThrowIfStopped();
            
            _applicationPoolFacade.RecycleApplicationPool(applicationPool);
        }
    }
}