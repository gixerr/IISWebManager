using System;
using IISWebManager.Core.Exceptions;

namespace IISWebManager.Core.Domain
{
    public class MissingApplicationPoolException : DomainException
    {
        public override string Code => "missing_application_application_pool";
        
        public MissingApplicationPoolException() : base("Application application pool is missing.")
        {
        }
    }
}