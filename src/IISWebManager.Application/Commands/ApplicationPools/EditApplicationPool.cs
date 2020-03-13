namespace IISWebManager.Application.Commands.ApplicationPools
{
    public class EditApplicationPool : ICommand
    {
        public string Name { get; set; }
        public string NewName { get; set; }
        public string ManagedPipelineMode { get; set; }
        public string ManagedRuntimeVersion { get; set; }
        public string Identity { get; set; }
    }
}