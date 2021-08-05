namespace IISWebManager.Application.Commands.ApplicationPools
{
    /// <summary>
    /// Application pool to update 
    /// </summary>
    public class UpdateApplicationPool : ICommand
    {
        /// <summary>
        /// Name of the application pool
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// New name of the application pool
        /// </summary>
        public string NewName { get; set; }
        
        /// <summary>
        /// Application pool managed pipeline mode
        /// </summary>
        public string ManagedPipelineMode { get; set; }
        
        /// <summary>
        /// Application pool managed runtime version
        /// </summary>
        public string ManagedRuntimeVersion { get; set; }
        
        /// <summary>
        /// Application pool identity
        /// </summary>
        public string Identity { get; set; }
    }
}