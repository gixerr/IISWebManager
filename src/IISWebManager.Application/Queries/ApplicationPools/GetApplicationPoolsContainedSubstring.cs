using System.Collections.Generic;
using IISWebManager.Application.DTO;

namespace IISWebManager.Application.Queries.ApplicationPools
{
    public class GetApplicationPoolsContainedSubstring : IQuery<IEnumerable<ApplicationPoolGetDto>>
    {
        public string Substring { get; set; }
    }
}