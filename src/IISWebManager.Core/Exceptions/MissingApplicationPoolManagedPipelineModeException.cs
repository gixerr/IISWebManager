using System;

namespace IISWebManager.Core.Exceptions
{
    public class MissingApplicationPoolManagedPipelineModeException : DomainException
    {
        public override string Code => "missing_application_pool_managed_pipeline_mode";
        
        public MissingApplicationPoolManagedPipelineModeException() 
            : base("Application pool managed pipeline mode is missing")
        {
        }
    }
}