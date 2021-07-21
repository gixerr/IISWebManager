using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetEditableApplicationProperties : IQuery<ApplicationEditablePropertiesDto>
    {
        public GetEditableApplicationProperties(string siteName, string applicationName)
        {
            SiteName = siteName;
            ApplicationName = applicationName;
        }
        public string SiteName { get; set; }
        public string ApplicationName { get; set; }
    }
}