using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetApplication : IQuery<ApplicationGetDto>
    {
        public GetApplication(string siteName, string applicationName)
        {
            SiteName = siteName;
            ApplicationName = applicationName;
        }
        public string SiteName { get; set; }
        public string ApplicationName { get; set; }
    }
}