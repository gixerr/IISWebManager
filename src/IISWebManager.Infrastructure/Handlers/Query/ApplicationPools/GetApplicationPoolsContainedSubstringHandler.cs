using System.Collections.Generic;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetApplicationPoolsContainedSubstringHandler : IQueryHandler<GetApplicationPoolsContainedSubstring,
        IEnumerable<ApplicationPoolGetDto>>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public GetApplicationPoolsContainedSubstringHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }
        public IEnumerable<ApplicationPoolGetDto> Handle(GetApplicationPoolsContainedSubstring query)
        {
            query.ThrowIfNull(GetType().Name);
            var applicationPools = _applicationPoolFacade.GetApplicationPools(query.Substring);

            return applicationPools.AsDto();
        }
    }
}