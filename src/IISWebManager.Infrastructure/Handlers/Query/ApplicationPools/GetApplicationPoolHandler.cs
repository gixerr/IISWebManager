using IISWebManager.Application.DTO;
using IISWebManager.Application.Exceptions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetApplicationPoolHandler : IQueryHandler<GetApplicationPool, ApplicationPoolGetDto>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;

        public GetApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade)
        {
            _applicationPoolFacade = applicationPoolFacade;
        }
        public ApplicationPoolGetDto Handle(GetApplicationPool query)
        {
            if (query is null)
            {
                throw new MissingQueryException($"Handler '{GetType().Name}' received null query.");
            }
            var applicationPool = _applicationPoolFacade.GetApplicationPool(query.Name);

            return applicationPool.AsDto();
        }
    }
}