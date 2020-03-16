using System.Collections.Generic;
using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;

namespace IISWebManager.Infrastructure.Handlers.Query.Applications
{
    public class GetApplicationsContainedSubstringHandler 
        : IQueryHandler<GetApplicationsContainedSubstring, IEnumerable<ApplicationGetDto>>
    {
        private readonly ISiteFacade _siteFacade;
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;

        public GetApplicationsContainedSubstringHandler(ISiteFacade siteFacade, IApplicationFacade applicationFacade, IMapper mapper)
        {
            _siteFacade = siteFacade;
            _applicationFacade = applicationFacade;
            _mapper = mapper;
        }
        public IEnumerable<ApplicationGetDto> Handle(GetApplicationsContainedSubstring query)
        {
            query.ThrowIfNull(GetType().Name);
            
            
            var applicationsDto = _mapper.Map<IEnumerable<ApplicationGetDto>>(applications);

            return applicationsDto;
        }

        private bool IsEmpty(string value)
            => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }
}