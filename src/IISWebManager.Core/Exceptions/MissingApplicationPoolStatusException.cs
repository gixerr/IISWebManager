using System;

namespace IISWebManager.Core.Exceptions
{
    public class MissingApplicationPoolStatusException : DomainException
    {
        public override string Code => "missing_application_pool_status";
        
        public MissingApplicationPoolStatusException() : base("Application pool status is missing.")
        {
        }
    }
}