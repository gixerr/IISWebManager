using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Facades
{
    public interface IApplicationPoolFacade
    {
        ApplicationPoolCollection BrowseApplicationPools();
        ApplicationPoolCollection GetApplicationPools(string subString);
        ApplicationPool GetApplicationPool(string name);
        void StartApplicationPool(ApplicationPool applicationPool);
        void StopApplicationPool(ApplicationPool applicationPool);
    }
}