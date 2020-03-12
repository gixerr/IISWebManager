using System.Linq;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Helpers
{
    public static class ApplicationPoolHelpers
    {
        public static int GetNumberOfApplicationPoolApplications(string applicationPoolName)
        {
            using var serverManager = new ServerManager();
            
            return serverManager.Sites
                .SelectMany(s => s.Applications
                    .Where(a => a.ApplicationPoolName.Equals(applicationPoolName)))
                .Count();
        }
    }
}