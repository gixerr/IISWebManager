using System.Collections.Generic;
using System.Linq;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Exceptions;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Extensions
{
    public static class ApplicationPoolExtensions
    {
        public static ApplicationPoolGetDto AsDto(this ApplicationPool applicationPool)
            => new ApplicationPoolGetDto(applicationPool.Name, applicationPool.ManagedRuntimeVersion,
                applicationPool.ManagedPipelineMode.ToString(), applicationPool.State.ToString());

        public static IEnumerable<ApplicationPoolGetDto> AsDto(this ApplicationPoolCollection applicationPoolCollection)
            => applicationPoolCollection
                .Select(x => new ApplicationPoolGetDto(x.Name, x.ManagedRuntimeVersion, 
                    x.ManagedPipelineMode.ToString(), x.State.ToString()));

        public static IEnumerable<ApplicationPoolGetDto> AsDto(this IEnumerable<ApplicationPool> applicationPools)
            => applicationPools
                .Select(x => new ApplicationPoolGetDto(x.Name, x.ManagedRuntimeVersion,
                    x.ManagedPipelineMode.ToString(), x.State.ToString()));

        public static void ThrowIfNull(this ApplicationPool applicationPool, string name)
        {
            if (applicationPool is null) throw new ApplicationPoolNotExistsException(name);
        }
    }
}