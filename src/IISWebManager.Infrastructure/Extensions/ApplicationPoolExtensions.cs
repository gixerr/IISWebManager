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

        public static void ThrowIfExists(this ApplicationPool applicationPool)
        {
            if (applicationPool is {}) throw new ApplicationPoolAlreadyExistsException(applicationPool.Name);
        }

        public static void ThrowIfStarted(this ApplicationPool applicationPool)
        {
            if (applicationPool.State.Equals(ObjectState.Started))
                throw new ApplicationPoolAlreadyStartedException(applicationPool.Name);
        }

        public static void ThrowIfStopped(this ApplicationPool applicationPool)
        {
            if (applicationPool.State.Equals(ObjectState.Stopped))
                throw new ApplicationPoolAlreadyStoppedException(applicationPool.Name);
        }
    }
}