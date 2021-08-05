using System.ComponentModel.DataAnnotations;

namespace IISWebManager.Application.Commands.ApplicationPools
{
    /// <summary>
    /// Application pool to stop
    /// </summary>
    public class StopApplicationPool : ICommand
    {
        /// <summary>
        /// Name of the application pool
        /// </summary>
        [Required]
        public string Name { get; }
        
        public StopApplicationPool(string applicationPoolName)
        {
            Name = applicationPoolName;
        }
        
    }
}