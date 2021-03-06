﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Facades.Applications;

namespace IISWebManager.Infrastructure.Handlers.Query.Applications
{
    public class BrowseApplicationsHandler : IQueryHandler<BrowseApplications, IEnumerable<ApplicationGetDto>>
    {
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;

        public BrowseApplicationsHandler(IApplicationFacade applicationFacade, IMapper mapper)
        {
            _applicationFacade = applicationFacade;
            _mapper = mapper;
        }
        public IEnumerable<ApplicationGetDto> Handle(BrowseApplications query)
        {
            query.ThrowIfNull(GetType().Name);
            var applications = _applicationFacade.BrowseApplications();
            var applicationsDto = _mapper.Map<IEnumerable<ApplicationGetDto>>(applications);

            return applicationsDto.OrderBy(x => x.Name);
        }
    }
}