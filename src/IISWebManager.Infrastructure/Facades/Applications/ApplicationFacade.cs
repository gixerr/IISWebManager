using System;
using System.Collections.Generic;
using System.Linq;
using IISWebManager.Core.Exceptions;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Utils;
using Microsoft.Web.Administration;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Facades.Applications
{
    public class ApplicationFacade : IApplicationFacade
    {
        private readonly ServerManager _serverManager;

        public ApplicationFacade(ServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        public IEnumerable<App> BrowseApplications()
            => _serverManager.Sites.SelectMany(x => x.Applications);

        public IEnumerable<App> GetApplications(string subString)
            => BrowseApplications()
                .Where(x => ApplicationUtils.ConvertPathToName(x.Path).ToLower().Contains(subString.ToLower()));

        public ApplicationCollection GetSiteApplications(Site site)
            => site.Applications;

        public IEnumerable<App> GetSiteApplications(string subString, Site site)
            => site.Applications.Where(x =>
                ApplicationUtils.ConvertPathToName(x.Path.ToLower()).Contains(subString.ToLower()));

        public App GetApplication(string name, Site site)
            => GetSiteApplications(site)
                    .SingleOrDefault(x =>
                        ApplicationUtils.ConvertPathToName(x.Path).Equals(name, StringComparison.OrdinalIgnoreCase));

        public void AddApplication(string name, string physicalPath, string applicationPoolName, Site site)
        {
            var path = ApplicationUtils.ConvertNameToPath(name);
            var application = site.Applications.Add(path, physicalPath);
            application.ApplicationPoolName = applicationPoolName;
            _serverManager.CommitChanges();
        }

        public void UpdateApplication()
        {
            throw new NotImplementedException();
        }

        public void DeleteApplication(App application)
        {
            application.Delete();
            _serverManager.CommitChanges();
        }
    }
}