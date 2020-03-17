using System;
using System.Collections.Generic;
using System.Linq;
using IISWebManager.Application.Exceptions;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Utils
{
    public static class ApplicationPoolUtils
    {
        private static readonly IDictionary<Type, Func<string, Exception>> EnumToExceptionMapper =
            new Dictionary<Type, Func<string, Exception>>
            {
                [typeof(ManagedPipelineMode)] = (name) => new InvalidManagedPipelineModeException(name),
                [typeof(ProcessModelIdentityType)] = (name) => new InvalidIdentityTypeException(name),
            };
        
        public static int GetNumberOfApplicationPoolApplications(string applicationPoolName)
        {
            using var serverManager = new ServerManager();

            return serverManager.Sites
                .SelectMany(s => s.Applications
                    .Where(a => a.ApplicationPoolName.Equals(applicationPoolName)))
                .Count();
        }

        public static TResult ParseToEnumOrThrow<TResult>(string value) where TResult : struct
            => Enum.TryParse(value, out TResult mode)
                ? mode
                : throw EnumToExceptionMapper[typeof(TResult)](value);
        
        public static string GetApplicationPoolStatus(string applicationPoolName)
        {
            using var serverManager = new ServerManager();
            
            return serverManager.ApplicationPools
                .Single(x => x.Name.Equals(applicationPoolName, StringComparison.OrdinalIgnoreCase))
                .State.ToString();
        }
    }
}