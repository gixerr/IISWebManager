using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Facades.Sites
{
    public interface ISiteFacade
    {
        Site GetSite(string name);
    }
}