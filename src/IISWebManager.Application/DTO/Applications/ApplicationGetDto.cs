namespace IISWebManager.Application.DTO.Applications
{
    public class ApplicationGetDto
    {
        public string Name { get; set; }
        public string ApplicationPoolName { get; set; }
        public string ApplicationPoolStatus { get; set; }
        public string PhysicalPath { get; set; }
    }
}