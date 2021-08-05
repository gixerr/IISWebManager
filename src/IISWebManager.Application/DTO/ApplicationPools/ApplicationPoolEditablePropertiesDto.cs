namespace IISWebManager.Application.DTO.ApplicationPools
{
    /// <summary>
    /// Application pool editable properties object
    /// </summary>
    public class ApplicationPoolEditablePropertiesDto
    {
        /// <summary>
        /// Name of the application pool
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Managed pipeline mode of the application pool
        /// </summary>
        public string ManagedPipelineMode { get; set; }
        
        /// <summary>
        /// Managed run time version of the application pool
        /// </summary>
        public string ManagedRuntimeVersion { get; set; }
        
        /// <summary>
        /// Identity of the application pool 
        /// </summary>
        public string Identity { get; set; }
    }
}