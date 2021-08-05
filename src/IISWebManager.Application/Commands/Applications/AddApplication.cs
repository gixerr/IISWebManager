using System.ComponentModel.DataAnnotations;

namespace IISWebManager.Application.Commands.Applications
{
    /// <summary>
    /// Application to add 
    /// </summary>
    public class AddApplication : ICommand
    {
        /// <summary>
        /// Name of the application
        /// </summary>
        [Required]
        public string ApplicationName { get; set; }
        
        /// <summary>
        /// Application physical path
        /// </summary>
        [Required]
        public string PhysicalPath { get; set; }
        
        /// <summary>
        /// Application pool name
        /// </summary>
        [Required]
        public string ApplicationPoolName { get; set; }
        
        /// <summary>
        /// Site name
        /// </summary>
        [Required]
        public string SiteName { get; set; }
    }
}