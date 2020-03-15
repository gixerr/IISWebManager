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

        public ApplicationCollection GetSiteApplications(string siteName)
        {
            var site = _serverManager.Sites
                .SingleOrDefault(x => x.Name.Equals(siteName, StringComparison.OrdinalIgnoreCase));
            site.ThrowIfNull(siteName);

            return site.Applications;
        }

        public IEnumerable<App> GetApplications(string subString, string siteName = null)
            => siteName is null
                ? BrowseApplications()
                    .Where(x => ApplicationUtils.ConvertPathToName(x.Path).ToLower().Contains(subString.ToLower()))
                : GetSiteApplications(siteName)
                    .Where(x => ApplicationUtils.ConvertPathToName(x.Path).ToLower().Contains(subString.ToLower()));

        public App GetApplication(string name, string siteName = null)
            => siteName is null
                ? BrowseApplications()
                    .SingleOrDefault(x =>
                        ApplicationUtils.ConvertPathToName(x.Path).Equals(name, StringComparison.OrdinalIgnoreCase))
                : GetSiteApplications(siteName)
                    .SingleOrDefault(x =>
                        ApplicationUtils.ConvertPathToName(x.Path).Equals(name, StringComparison.OrdinalIgnoreCase));

        public void AddApplication(string name, string physicalPath, string applicationPoolName, string siteName)
        {
            var site = _serverManager.Sites
                .SingleOrDefault(x => x.Name.Equals(siteName, StringComparison.OrdinalIgnoreCase));
            site.ThrowIfNull(siteName);
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