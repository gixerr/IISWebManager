using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Facades.Applications;

namespace IISWebManager.Infrastructure.Handlers.Query.Applications
{
    public class GetSiteApplicationsHandler : IQueryHandler<GetSiteApplications, IEnumerable<ApplicationGetDto>>
    {
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;

        public GetSiteApplicationsHandler(IApplicationFacade applicationFacade, IMapper mapper)
        {
            _applicationFacade = applicationFacade;
            _mapper = mapper;
        }
        
        public IEnumerable<ApplicationGetDto> Handle(GetSiteApplications query)
        {
            query.ThrowIfNull(GetType().Name);
            var applications = _applicationFacade.GetSiteApplications(query.Name);
            var applicationsDto = applications.Select(_mapper.Map<ApplicationGetDto>);

            return applicationsDto.OrderBy(x => x.Name);
        }
    }
}