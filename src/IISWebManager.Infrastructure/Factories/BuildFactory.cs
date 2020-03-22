using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IISWebManager.Application.DTO.ApplicationPools;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Core.Contracts;
using IISWebManager.Core.Domain;
using IISWebManager.Core.Enums;
using IISWebManager.Core.ValueObjects;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Settings;
using IISWebManager.Infrastructure.Utils;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Factories
{
    public class BuildFactory : IBuildFactory
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly BuildSettings _buildSettings;

        public BuildFactory(IApplicationPoolFacade applicationPoolFacade, BuildSettings buildSettings)
        {
            _applicationPoolFacade = applicationPoolFacade;
            _buildSettings = buildSettings;
        }

        public IEnumerable<Build> ConstructFrom(IEnumerable<App> applicationCollection)
        {
            var buildApplications = MapToBuildApplications(applicationCollection).ToList();

            var builds = buildApplications
                .Where(x => !x.Name.Contains(_buildSettings.NamingConventionSeparator) && !string.IsNullOrEmpty(x.Name))
                .Select(x => new Build(x.Name, InferBuildStatus(buildApplications, x.Name).ToString(),
                    GatherBuildApps(buildApplications, x.Name)));

            return builds;
        }

        private IEnumerable<BuildApplication> MapToBuildApplications(IEnumerable<App> applicationCollection)
            => applicationCollection.Where(x => PathIsDesired(x.Path))
                .Select(x => new BuildApplication(ApplicationUtils.ConvertPathToName(x.Path),
                    GetApplicationPoolDto(x.ApplicationPoolName)));

        private BuildApplicationPool GetApplicationPoolDto(string name)
        {
            var applicationPool = _applicationPoolFacade.GetApplicationPool(name);

            return new BuildApplicationPool(applicationPool.Name, applicationPool.State.ToString());
        }

        private IEnumerable<IApplication> GatherBuildApps(
            IEnumerable<IApplication> apps, string appName)
            => apps.Where(x => x.Name.Contains($"{appName}{_buildSettings.NamingConventionSeparator}") 
                               || x.Name.Equals(appName))
                .OrderBy(x => x.Name);

        private BuildStatus InferBuildStatus(IEnumerable<IApplication> apps,
            string appName)
        {
            var buildApps = GatherBuildApps(apps, appName);
            var appPoolStatuses = buildApps.Select(x => x.ApplicationPool.Status).ToList();

            var stopped = BuildStatus.Stopped.ToString();
            if (appPoolStatuses.All(x => x.Equals(stopped, StringComparison.OrdinalIgnoreCase)))
            {
                return BuildStatus.Stopped;
            }

            return appPoolStatuses.Any(x => x.Equals(stopped, StringComparison.OrdinalIgnoreCase))
                ? BuildStatus.Error
                : BuildStatus.Running;
        }

        private bool PathIsDesired(string path)
            => !_buildSettings.UndesiredPaths.Contains(path);
        

    }
}