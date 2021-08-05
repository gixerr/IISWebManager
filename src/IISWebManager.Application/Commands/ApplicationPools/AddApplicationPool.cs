using System.ComponentModel.DataAnnotations;

namespace IISWebManager.Application.Commands.ApplicationPools
{
    /// <summary>
    /// Application pool to add 
    /// </summary>
    public class AddApplicationPool : ICommand
    {
        /// <summary>
        /// Name of the application pool
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Application pool managed pipeline mode
        /// </summary>
        [Required]
        public string ManagedPipelineMode { get; set; }
        
        /// <summary>
        /// Application pool managed runtime version
        /// </summary>
        [Required]
        public string ManagedRuntimeVersion { get; set; }
        
        /// <summary>
        /// Should application pool start automatically
        /// </summary>
        [Required]
        public bool AutoStart { get; set; } = true;
    }
}