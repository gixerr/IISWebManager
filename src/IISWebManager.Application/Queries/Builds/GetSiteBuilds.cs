using System.Collections.Generic;
using IISWebManager.Application.DTO.Builds;

namespace IISWebManager.Application.Queries.Builds
{
    public class GetSiteBuilds : IQuery<IEnumerable<BuildGetDto>>
    {
        public GetSiteBuilds(string siteName)
        {
            SiteName = siteName;
        }

        public string SiteName { get; set; }
    }
}