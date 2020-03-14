using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IISWebManager.Application.DTO.ApplicationPools;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.ApplicationPools;
using IISWebManager.Infrastructure.Facades.ApplicationPools;
using IISWebManager.Infrastructure.Utils;

namespace IISWebManager.Infrastructure.Handlers.Query.ApplicationPools
{
    public class GetApplicationPoolsContainedSubstringHandler : IQueryHandler<GetApplicationPoolsContainedSubstring,
        IEnumerable<ApplicationPoolGetDto>>
    {
        private readonly IApplicationPoolFacade _applicationPoolFacade;
        private readonly IMapper _mapper;

        public GetApplicationPoolsContainedSubstringHandler(IApplicationPoolFacade applicationPoolFacade,
            IMapper mapper)
        {
            _applicationPoolFacade = applicationPoolFacade;
            _mapper = mapper;
        }

        public IEnumerable<ApplicationPoolGetDto> Handle(GetApplicationPoolsContainedSubstring query)
        {
            query.ThrowIfNull(GetType().Name);
            var applicationPools = _applicationPoolFacade.GetApplicationPools(query.Substring);
            var applicationPoolsDto = _mapper.Map<IEnumerable<ApplicationPoolGetDto>>(applicationPools).ToList();

            return applicationPoolsDto;
        }
    }
}