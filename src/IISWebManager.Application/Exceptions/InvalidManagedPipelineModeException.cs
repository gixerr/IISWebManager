namespace IISWebManager.Application.Exceptions
{
    public class InvalidManagedPipelineModeException : ApplicationException
    {
        public override string Code => "invalid_managed_pipeline_mode";
        
        public InvalidManagedPipelineModeException(string managedPipelineMode) 
            : base($"Managed pipeline mode '{managedPipelineMode}' is invalid.")
        {
        }

    }
}