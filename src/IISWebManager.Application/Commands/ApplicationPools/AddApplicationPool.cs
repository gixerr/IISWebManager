namespace IISWebManager.Application.Commands.ApplicationPools
{
    public class AddApplicationPool : ICommand
    {
        public string Name { get; set; }
        public string ManagedPipelineMode { get; set; }
        public string ManagedRuntimeVersion { get; set; }
    }
}