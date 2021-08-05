namespace IISWebManager.Application.Commands.Applications
{
    /// <summary>
    /// Application to delete
    /// </summary>
    public class DeleteApplication : ICommand
    {
        /// <summary>
        /// Site name
        /// </summary>
        public string SiteName { get; set; }
        
        /// <summary>
        /// Application name
        /// </summary>
        public string ApplicationName { get; set; }
    }
}