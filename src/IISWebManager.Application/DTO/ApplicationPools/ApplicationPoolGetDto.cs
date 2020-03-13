namespace IISWebManager.Application.DTO.ApplicationPools
{
    public class ApplicationPoolGetDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string ManagedRuntimeVersion { get; set; }
        public string ManagedPipelineMode { get; set; }
        public string Identity { get; set; }
        public int Applications { get; set; }
    }
}