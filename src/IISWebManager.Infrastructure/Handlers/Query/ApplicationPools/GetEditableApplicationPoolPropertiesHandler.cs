using AutoMapper;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades;
using IISWebManager.Infrastructure.Facades.ApplicationPools;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetEditableApplicationPoolPropertiesHandler 
        : IQueryHandler<GetEditableApplicationPoolProperties, ApplicationPoolEditablePropertiesDto>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly IMapper _mapper;

        public GetEditableApplicationPoolPropertiesHandler(IApplicationPoolFacade applicationPoolFacade, IMapper mapper)
        {
            _applicationPoolFacade = applicationPoolFacade;
            _mapper = mapper;
        }
        public ApplicationPoolEditablePropertiesDto Handle(GetEditableApplicationPoolProperties query)
        {
            query.ThrowIfNull(GetType().Name);
            var applicationPool = _applicationPoolFacade.GetApplicationPool(query.Name);
            applicationPool.ThrowIfNull(query.Name);
            var applicationPoolDto = _mapper.Map<ApplicationPoolEditablePropertiesDto>(applicationPool);

            return applicationPoolDto;
        }
    }
}