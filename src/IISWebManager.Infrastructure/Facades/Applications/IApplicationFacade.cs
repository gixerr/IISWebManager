using System.Collections.Generic;
using Microsoft.Web.Administration;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Facades.Applications
{
    public interface IApplicationFacade
    {
        IEnumerable<App> BrowseApplications();
        ApplicationCollection GetSiteApplications(string siteName);
    }
}