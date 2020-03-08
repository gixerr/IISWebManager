using System;
using System.Collections.Generic;
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
            =>  _serverManager.ApplicationPools.Where(x => x.Name.Contains(subString));

        public ApplicationPool GetApplicationPool(string name) =>
            _serverManager.ApplicationPools
                .SingleOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public void StartApplicationPool(ApplicationPool applicationPool)
            => applicationPool.Start();

        public void StopApplicationPool(ApplicationPool applicationPool) 
            => applicationPool.Stop();
    }
}