using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Facades
{
    public class ApplicationPoolFacade : IApplicationPoolFacade
    {
        private readonly ServerManager _serverManager;

        public ApplicationPoolFacade(ServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        public ApplicationPoolCollection BrowseApplicationPools()
            => _serverManager.ApplicationPools;

        public IEnumerable<ApplicationPool> GetApplicationPools(string subString)
            => _serverManager.ApplicationPools.Where(x => x.Name.ToLower().Contains(subString.ToLower()));

        public ApplicationPool GetApplicationPool(string name) =>
            _serverManager.ApplicationPools
                .SingleOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public void StartApplicationPool(ApplicationPool applicationPool)
            => applicationPool.Start();

        public void StopApplicationPool(ApplicationPool applicationPool)
            => applicationPool.Stop();

        public void AddApplicationPool(string name, ManagedPipelineMode managedPipelineMode,
            string managedRuntimeVersion, bool autoStart)
        {
            var applicationPool = _serverManager.ApplicationPools.Add(name);
            applicationPool.ManagedPipelineMode = managedPipelineMode;
            applicationPool.ManagedRuntimeVersion = managedRuntimeVersion;
            applicationPool.AutoStart = autoStart;
            _serverManager.CommitChanges();
        }

        public void DeleteApplicationPool(ApplicationPool applicationPool)
        {
            _serverManager.ApplicationPools.Remove(applicationPool);
            _serverManager.CommitChanges();
        }
    }
}