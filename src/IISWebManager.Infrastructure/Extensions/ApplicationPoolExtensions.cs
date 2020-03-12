using IISWebManager.Application.Exceptions;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Extensions
{
    public static class ApplicationPoolExtensions
    {
        public static void ThrowIfNull(this ApplicationPool applicationPool, string name)
        {
            if (applicationPool is null) throw new ApplicationPoolNotExistsException(name);
        }
    }
}