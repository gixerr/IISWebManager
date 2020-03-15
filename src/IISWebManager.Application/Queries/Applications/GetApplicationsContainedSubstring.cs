using System.Collections.Generic;
using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetApplicationsContainedSubstring : IQuery<IEnumerable<ApplicationGetDto>>
    {
        public string SubString { get; set; }
        public string SiteName { get; set; }
    }
}