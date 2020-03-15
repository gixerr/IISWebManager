using System.Collections.Generic;
using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Facades.Applications;

namespace IISWebManager.Infrastructure.Handlers.Query.Applications
{
    public class GetApplicationsContainedSubstringHandler 
        : IQueryHandler<GetApplicationsContainedSubstring, IEnumerable<ApplicationGetDto>>
    {
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;

        public GetApplicationsContainedSubstringHandler(IApplicationFacade applicationFacade, IMapper mapper)
        {
            _applicationFacade = applicationFacade;
            _mapper = mapper;
        }
        public IEnumerable<ApplicationGetDto> Handle(GetApplicationsContainedSubstring query)
        {
            query.ThrowIfNull(GetType().Name);
            var applications = _applicationFacade.GetApplications(query.SubString, query.SiteName);
            var applicationsDto = _mapper.Map<IEnumerable<ApplicationGetDto>>(applications);

            return applicationsDto;
        }
    }
}