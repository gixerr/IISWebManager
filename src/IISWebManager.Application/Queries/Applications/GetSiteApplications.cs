using System.Collections.Generic;
using IISWebManager.Application.DTO.Applications;

namespace IISWebManager.Application.Queries.Applications
{
    public class GetSiteApplications : IQuery<IEnumerable<ApplicationGetDto>>
    {
        public string SiteName { get; set; }
    }
}