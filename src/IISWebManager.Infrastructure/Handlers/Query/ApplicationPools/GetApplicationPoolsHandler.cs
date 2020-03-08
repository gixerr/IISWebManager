using System.Collections.Generic;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Exceptions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetApplicationPoolsHandler : IQueryHandler<BrowseApplicationPools, IEnumerable<ApplicationPoolGetDto>>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public GetApplicationPoolsHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }
        public IEnumerable<ApplicationPoolGetDto> Handle(BrowseApplicationPools query)
        {
            if (query is null)
            {
                throw new MissingQueryException($"Handler '{GetType().Name}' received null query.");
            }
            var applicationPools = _applicationPoolFacade.BrowseApplicationPools();

            return applicationPools.AsDto();
        }
    }
}
