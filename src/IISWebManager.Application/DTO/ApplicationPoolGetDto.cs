namespace IISWebManager.Application.DTO
{
    public class ApplicationPoolGetDto
    {
        public ApplicationPoolGetDto(string name, string managedRuntimeVersion, string managedPipelineMode, string status)
        {
            Name = name;
            ManagedRuntimeVersion = managedRuntimeVersion;
            ManagedPipelineMode = managedPipelineMode;
            Status = status;
        }
        public string Name { get; set; }
        public string ManagedRuntimeVersion { get; set; }
        public string ManagedPipelineMode { get; set; }
        public string Status { get; set; }
    }
}