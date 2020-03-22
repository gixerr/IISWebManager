using System.Collections.Generic;
using IISWebManager.Core.Domain;
using App = Microsoft.Web.Administration.Application;
namespace IISWebManager.Infrastructure.Factories
{
    public interface IBuildFactory
    {
        IEnumerable<Build> ConstructFrom(IEnumerable<App> applicationCollection);
    }
}