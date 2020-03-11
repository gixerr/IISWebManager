using AutoMapper;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetDetailedApplicationPoolHandler : IQueryHandler<GetDetailedApplicationPool, ApplicationPoolGetDetailedDto>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly IMapper _mapper;

        public GetDetailedApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade, IMapper mapper)
        {
            _applicationPoolFacade = applicationPoolFacade;
            _mapper = mapper;
        }
        public ApplicationPoolGetDetailedDto Handle(GetDetailedApplicationPool query)
        {
            query.ThrowIfNull(GetType().Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(query.Name);
            applicationPool.ThrowIfNull(query.Name);
            var applicationPoolDto = _mapper.Map<ApplicationPoolGetDetailedDto>(applicationPool);

            return applicationPoolDto;
        }
    }
}