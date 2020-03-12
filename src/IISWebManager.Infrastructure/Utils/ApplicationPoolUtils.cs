using System;
using System.Linq;
using IISWebManager.Application.Exceptions;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Utils
{
    public static class ApplicationPoolUtils
    {
        public static int GetNumberOfApplicationPoolApplications(string applicationPoolName)
        {
            using var serverManager = new ServerManager();

            return serverManager.Sites
                .SelectMany(s => s.Applications
                    .Where(a => a.ApplicationPoolName.Equals(applicationPoolName)))
                .Count();
        }

        public static ManagedPipelineMode ParseToEnumOrThrow(string value)
            => Enum.TryParse(value, out ManagedPipelineMode mode)
                ? mode
                : throw new InvalidManagedPipelineModeException(value);
    }
}