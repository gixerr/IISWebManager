using System.Collections.Generic;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Exceptions;
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
            if (query is null)
            {
                throw new MissingQueryException($"Handler '{GetType().Name}' received null query.");
            }
            var applicationPools = _applicationPoolFacade.GetApplicationPools(query.Substring);

            return applicationPools.AsDto();
        }
    }
}