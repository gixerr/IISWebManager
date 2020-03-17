using IISWebManager.Application.Commands.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;

namespace IISWebManager.Infrastructure.Handlers.Commands.Applications
{
    public class AddApplicationHandler : ICommandHandler<AddApplication>
    {
        private readonly ISiteFacade _siteFacade;
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly IApplicationFacade _applicationFacade;

        public AddApplicationHandler(ISiteFacade siteFacade, IApplicationPoolFacade applicationPoolFacade,
            IApplicationFacade applicationFacade)
        {
            _siteFacade = siteFacade;
            _applicationPoolFacade = applicationPoolFacade;
            _applicationFacade = applicationFacade;
        }

        public void Handle(AddApplication command)
        {
            command.ThrowIfNull(GetType().Name);
            var site = _siteFacade.GetSite(command.SiteName);
            site.ThrowIfNull(command.SiteName);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.ApplicationPoolName);
            applicationPool.ThrowIfNull(command.ApplicationPoolName);
            var application = _applicationFacade.GetApplication(command.Name, site);
            application.ThrowIfExists();

            _applicationFacade.AddApplication(command.Name, command.PhysicalPath, command.ApplicationPoolName, site);
        }
    }
}