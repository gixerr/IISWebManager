using IISWebManager.Application.Exceptions;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Extensions
{
    public static class ApplicationExtensions 
    {
        public static void ThrowIfNull(this App application, string name)
        {
            if (application is null) throw new ApplicationNotExistsException(name);
        }
    }
}