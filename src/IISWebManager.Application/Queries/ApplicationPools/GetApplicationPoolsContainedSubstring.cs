using System.Collections.Generic;
using IISWebManager.Application.DTO.ApplicationPools;

namespace IISWebManager.Application.Queries.ApplicationPools
{
    public class GetApplicationPoolsContainedSubstring : IQuery<IEnumerable<ApplicationPoolGetDto>>
    {
        public GetApplicationPoolsContainedSubstring(string substring)
        {
            Substring = substring;
        }

        public string Substring { get; set; }
    }
}