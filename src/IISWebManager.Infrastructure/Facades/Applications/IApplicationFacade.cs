using System.Collections.Generic;
using IISWebManager.Application.Exceptions;
using Microsoft.Web.Administration;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Facades.Applications
{
    public interface IApplicationFacade
    {
        IEnumerable<App> BrowseApplications();
        ApplicationCollection GetSiteApplications(string siteName);
        IEnumerable<App> GetApplications(string subString, string siteName);
        App GetApplication(string name, string siteName);
        void AddApplication(string name, string physicalPath, string applicationPoolName, string siteName);
        void UpdateApplication();
        void DeleteApplication(App application);
    }
}