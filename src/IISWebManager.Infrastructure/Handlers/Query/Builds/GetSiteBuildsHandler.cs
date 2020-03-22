using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IISWebManager.Application.DTO.Builds;
using IISWebManager.Application.Queries.Builds;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;
using IISWebManager.Infrastructure.Factories;

namespace IISWebManager.Infrastructure.Handlers.Query.Builds
{
    public class GetSiteBuildsHandler : IQueryHandler<GetSiteBuilds, IEnumerable<BuildGetDto>>
    {
        private readonly ISiteFacade _siteFacade;
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;
        private readonly IBuildFactory _buildFactory;

        public GetSiteBuildsHandler(ISiteFacade siteFacade, IApplicationFacade applicationFacade, IMapper mapper,
            IBuildFactory buildFactory)
        {
            _siteFacade = siteFacade;
            _applicationFacade = applicationFacade;
            _mapper = mapper;
            _buildFactory = buildFactory;
        }

        public IEnumerable<BuildGetDto> Handle(GetSiteBuilds query)
        {
            var site = _siteFacade.GetSite(query.SiteName);
            site.ThrowIfNull(query.SiteName);
            var applications = _applicationFacade.GetSiteApplications(site);
            var builds = _buildFactory.ConstructFrom(applications).OrderBy(x => x.Name);
            var buildsDto = _mapper.Map<IEnumerable<BuildGetDto>>(builds);

            return buildsDto;
        }
    }
}