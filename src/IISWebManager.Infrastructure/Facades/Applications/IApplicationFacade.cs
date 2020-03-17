using System.Collections.Generic;
using Microsoft.Web.Administration;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Facades.Applications
{
    public interface IApplicationFacade
    {
        IEnumerable<App> BrowseApplications();
        IEnumerable<App> GetApplications(string substring);
        ApplicationCollection GetSiteApplications(Site site);
        IEnumerable<App> GetSiteApplications(string subString, Site site);
        App GetApplication(string name, Site site);
        void AddApplication(string name, string physicalPath, string applicationPoolName, Site site);
        void UpdateApplication();
        void DeleteApplication(App application);
    }
}