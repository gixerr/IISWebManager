using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetEditableApplicationProperties : IQuery<ApplicationEditablePropertiesDto>
    {
        public string SiteName { get; set; }
        public string ApplicationName { get; set; }
    }
}