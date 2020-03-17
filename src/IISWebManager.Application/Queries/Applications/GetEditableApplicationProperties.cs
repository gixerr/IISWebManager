using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetEditableApplicationProperties : IQuery<ApplicationEditablePropertiesDto>
    {
        public string Name { get; set; }
        public string SiteName { get; set; }
    }
}