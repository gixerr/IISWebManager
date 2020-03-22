using System.Collections.Generic;
using IISWebManager.Application.DTO.Builds;

namespace IISWebManager.Application.Queries.Builds
{
    public class GetSiteBuilds : IQuery<IEnumerable<BuildGetDto>>
    {
        public string SiteName { get; set; }
    }
}