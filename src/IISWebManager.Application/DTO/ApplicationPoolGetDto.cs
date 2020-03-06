namespace IISWebManager.Application.DTO
{
    public class ApplicationPoolGetDto
    {
        public ApplicationPoolGetDto(string name, string managedRuntimeVersion, string managedPipelineMode)
        {
            Name = name;
            ManagedRuntimeVersion = managedRuntimeVersion;
            ManagedPipelineMode = managedPipelineMode;
        }
        public string Name { get; set; }
        public string ManagedRuntimeVersion { get; set; }
        public string ManagedPipelineMode { get; set; }
    }
}