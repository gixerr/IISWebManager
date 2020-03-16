using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;

namespace IISWebManager.Infrastructure.Handlers.Query.Applications
{
    public class GetSiteApplicationsHandler : IQueryHandler<GetSiteApplications, IEnumerable<ApplicationGetDto>>
    {
        private readonly ISiteFacade _siteFacade;
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;

        public GetSiteApplicationsHandler(ISiteFacade siteFacade, IApplicationFacade applicationFacade, IMapper mapper)
        {
            _siteFacade = siteFacade;
            _applicationFacade = applicationFacade;
            _mapper = mapper;
        }
        
        public IEnumerable<ApplicationGetDto> Handle(GetSiteApplications query)
        {
            query.ThrowIfNull(GetType().Name);
            var site = _siteFacade.GetSite(query.Name);
            site.ThrowIfNull(query.Name);
            var applications = _applicationFacade.GetSiteApplications(site);
            var applicationsDto = applications.Select(_mapper.Map<ApplicationGetDto>);

            return applicationsDto.OrderBy(x => x.Name);
        }
    }
}