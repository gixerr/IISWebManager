namespace IISWebManager.Application.Commands.Applications
{
    /// <summary>
    /// Application to update 
    /// </summary>
    public class UpdateApplication : ICommand
    {
        /// <summary>
        /// Site name
        /// </summary>
        public string SiteName { get; set; }
        
        /// <summary>
        /// Application to update name
        /// </summary>
        public string ApplicationName { get; set; }
        
        /// <summary>
        /// New application name
        /// </summary>
        public string NewApplicationName { get; set; }
        
        /// <summary>
        /// Application pool name
        /// </summary>
        public string ApplicationPoolName { get; set; }
        
        /// <summary>
        /// Application physical path
        /// </summary>
        public string PhysicalPath { get; set; }
    }
}