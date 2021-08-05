namespace IISWebManager.Application.DTO.ApplicationPools
{
    /// <summary>
    /// Application pool 'GET' object
    /// </summary>
    public class ApplicationPoolGetDto
    {
        /// <summary>
        /// Name of the application pool
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Status of the application pool
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Managed run time version of the application pool
        /// </summary>
        public string ManagedRuntimeVersion { get; set; }
        
        /// <summary>
        /// Managed pipeline mode of the application pool
        /// </summary>
        public string ManagedPipelineMode { get; set; }
        
        /// <summary>
        /// Identity of the application pool 
        /// </summary>
        public string Identity { get; set; }
        
        /// <summary>
        /// Number of applications running on this application pool
        /// </summary>
        public int Applications { get; set; }
    }
}