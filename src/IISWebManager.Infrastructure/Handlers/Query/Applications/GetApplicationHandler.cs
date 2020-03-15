using AutoMapper;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Application.Extensions;
using IISWebManager.Application.Queries.Applications;
using IISWebManager.Infrastructure.Extensions;
using IISWebManager.Infrastructure.Facades.Applications;

namespace IISWebManager.Infrastructure.Handlers.Query.Applications
{
    public class GetApplicationHandler : IQueryHandler<GetApplication, ApplicationGetDto>
    {
        private readonly IApplicationFacade _applicationFacade;
        private readonly IMapper _mapper;

        public GetApplicationHandler(IApplicationFacade applicationFacade, IMapper mapper)
        {
            _applicationFacade = applicationFacade;
            _mapper = mapper;
        }
        public ApplicationGetDto Handle(GetApplication query)
        {
            query.ThrowIfNull(GetType().Name);
            var application = _applicationFacade.GetApplication(query.Name, query.SiteName);
            application.ThrowIfNull(query.Name);
            var applicationDto = _mapper.Map<ApplicationGetDto>(application);

            return applicationDto;
        }
    }
}