using System;
using System.Linq;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Facades.Sites
{
    public class SiteFacade : ISiteFacade
    {
        private readonly ServerManager _serverManager;

        public SiteFacade(ServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        public Site GetSite(string name) 
            => _serverManager.Sites.SingleOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}