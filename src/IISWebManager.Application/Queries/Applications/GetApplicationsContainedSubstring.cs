using System.Collections.Generic;
using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetApplicationsContainedSubstring : IQuery<IEnumerable<ApplicationGetDto>>
    {
        public GetApplicationsContainedSubstring(string siteName, string subString)
        {
            SiteName = siteName;
            SubString = subString;
        }
        public string SiteName { get; set; }
        public string SubString { get; set; }
    }
}