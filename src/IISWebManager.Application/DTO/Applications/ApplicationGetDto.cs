namespace IISWebManager.Application.DTO.Applications
{
    /// <summary>
    /// Application 'GET' object
    /// </summary>
    public class ApplicationGetDto
    {
        /// <summary>
        /// Name of the application
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Name of the application pool
        /// </summary>
        public string ApplicationPoolName { get; set; }
        
        /// <summary>
        /// Status of the application pool
        /// </summary>
        public string ApplicationPoolStatus { get; set; }
        
        /// <summary>
        /// Physical path of the application
        /// </summary>
        public string PhysicalPath { get; set; }
    }
}