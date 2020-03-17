using IISWebManager.Application.Commands.Applications;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;

namespace IISWebManager.Infrastructure.Handlers.Commands.Applications
{
    public class DeleteApplicationHandler : ICommandHandler<DeleteApplication>
    {
        private readonly ISiteFacade _siteFacade;
        private readonly IApplicationFacade _applicationFacade;

        public DeleteApplicationHandler(ISiteFacade siteFacade, IApplicationFacade applicationFacade)
        {
            _siteFacade = siteFacade;
            _applicationFacade = applicationFacade;
        }
        public void Handle(DeleteApplication command)
        {
            var site = _siteFacade.GetSite(command.SiteName);
            site.ThrowIfNull(command.SiteName);
            var application = _applicationFacade.GetApplication(command.ApplicationName, site);
            application.ThrowIfNull(command.ApplicationName);
            
            _applicationFacade.DeleteApplication(application, site);
        }
    }
}