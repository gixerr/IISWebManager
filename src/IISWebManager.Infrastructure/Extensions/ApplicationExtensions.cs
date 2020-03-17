using IISWebManager.Application.Exceptions;
using IISWebManager.Infrastructure.Utils;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Extensions
{
    public static class ApplicationExtensions 
    {
        public static void ThrowIfNull(this App application, string name)
        {
            if (application is null) throw new ApplicationNotExistsException(name);
        }

        public static void ThrowIfExists(this App application)
        {
            if (application is {})
                throw new ApplicationAlreadyExistsException(ApplicationUtils.ConvertPathToName(application.Path));
        }
    }
}