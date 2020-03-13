namespace IISWebManager.Application.DTO
{
    public class ApplicationPoolEditablePropertiesDto
    {
        public string Name { get; set; }
        public string ManagedPipelineMode { get; set; }
        public string ManagedRuntimeVersion { get; set; }
        public string Identity { get; set; }
    }
}