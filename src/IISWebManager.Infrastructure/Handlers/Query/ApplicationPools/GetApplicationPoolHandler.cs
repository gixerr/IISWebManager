using AutoMapper;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Utils;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetApplicationPoolHandler : IQueryHandler<GetApplicationPool, ApplicationPoolGetDto>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly IMapper _mapper;

        public GetApplicationPoolHandler(IApplicationPoolFacade applicationPoolFacade, IMapper mapper)
        {
            _applicationPoolFacade = applicationPoolFacade;
            _mapper = mapper;
        }
        public ApplicationPoolGetDto Handle(GetApplicationPool query)
        {
            query.ThrowIfNull(GetType().Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(query.Name);
            applicationPool.ThrowIfNull(query.Name);
            var applicationPoolDto = _mapper.Map<ApplicationPoolGetDto>(applicationPool);
            applicationPoolDto.Applications = ApplicationPoolUtils
                .GetNumberOfApplicationPoolApplications(applicationPoolDto.Name);

            return applicationPoolDto;
        }
    }
}