using System.Collections.Generic;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Exceptions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Query
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
                throw new MissingQueryException($"Query '{query.GetType().Name}' can't be null");
            }
            var applicationPools = _applicationPoolFacade.BrowseApplicationPools().AsDto();

            return applicationPools;
        }
    }
}