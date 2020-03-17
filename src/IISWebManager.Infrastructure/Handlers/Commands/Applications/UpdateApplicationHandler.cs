using IISWebManager.Application.Commands.Applications;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;
using IISWebManager.Infrastructure.Utils;

namespace IISWebManager.Infrastructure.Handlers.Commands.Applications
{
    public class UpdateApplicationHandler : ICommandHandler<UpdateApplication>
    {
        private readonly ISiteFacade _siteFacade;
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly IApplicationFacade _applicationFacade;

        public UpdateApplicationHandler(ISiteFacade siteFacade, IApplicationPoolFacade applicationPoolFacade,
            IApplicationFacade applicationFacade)
        {
            _siteFacade = siteFacade;
            _applicationPoolFacade = applicationPoolFacade;
            _applicationFacade = applicationFacade;
        }

        public void Handle(UpdateApplication command)
        {
            var site = _siteFacade.GetSite(command.SiteName);
            site.ThrowIfNull(command.SiteName);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(command.ApplicationPoolName);
            applicationPool.ThrowIfNull(command.ApplicationPoolName);
            var application = _applicationFacade.GetApplication(command.ApplicationName, site);
            application.ThrowIfNull(command.ApplicationName);
            
            application.Path = ApplicationUtils.ConvertNameToPath(command.NewApplicationName);
            application.ApplicationPoolName = command.ApplicationPoolName;
            application.VirtualDirectories["/"].PhysicalPath = command.PhysicalPath;
            
            _applicationFacade.UpdateApplication();
        }
    }
}