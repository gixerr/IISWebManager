namespace IISWebManager.Application.DTO
{
    public class ApplicationPoolGetDetailedDto
    {
        public string Name { get; set; }
        public string ManagedRuntimeVersion { get; set; }
        public string ManagedPipelineMode { get; set; }
        public string Identity { get; set; }
        public string StartMode { get; set; }
    }
}