using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IISWebManager.Application.DTO;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Facades;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetApplicationPoolsHandler : IQueryHandler<BrowseApplicationPools, IEnumerable<ApplicationPoolGetDto>>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly IMapper _mapper;

        public GetApplicationPoolsHandler(IApplicationPoolFacade applicationPoolFacade, IMapper mapper)
        {
            _applicationPoolFacade = applicationPoolFacade;
            _mapper = mapper;
        }
        public IEnumerable<ApplicationPoolGetDto> Handle(BrowseApplicationPools query)
        {
            query.ThrowIfNull(GetType().Name);
            var applicationPools = _applicationPoolFacade.BrowseApplicationPools();
            var applicationPoolsDto = applicationPools.Select(_mapper.Map<ApplicationPoolGetDto>);
            
            return applicationPoolsDto.OrderBy(x => x.Name);
        }
    }
}
