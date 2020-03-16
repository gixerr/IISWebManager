using System.Collections.Generic;
using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.Applications;
using IISWebManager.Infrastructure.Facades.Sites;
using App = Microsoft.Web.Administration.Application;

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
            var applications = IsEmpty(query.SiteName)
                ? _applicationFacade.GetApplications(query.SubString)
                : GetSiteApplications(query.SubString, query.SiteName);
   
            var applicationsDto = _mapper.Map<IEnumerable<ApplicationGetDto>>(applications);

            return applicationsDto;
        }

        private static bool IsEmpty(string value)
            => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

        private IEnumerable<App> GetSiteApplications(string subString, string siteName)
        {
            var site = _siteFacade.GetSite(siteName);
            site.ThrowIfNull(siteName);
            var applications = _applicationFacade.GetSiteApplications(subString, site);

            return applications;
        }
    }
}