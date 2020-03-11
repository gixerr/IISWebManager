using AutoMapper;
using IISWebManager.Application.DTO;
using Microsoft.Web.Administration;

namespace IISWebManager.Infrastructure.Mappers
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ApplicationPool, ApplicationPoolGetDto>()
                        .ForMember(dm => dm.Status, o => o.MapFrom(sm => sm.State));
                    
                    cfg.CreateMap<ApplicationPool, ApplicationPoolGetDetailedDto>()
                        .ForMember(dm => dm.Identity, o => o.MapFrom(sm => sm.ProcessModel.IdentityType.ToString()))
                        .ForMember(dm => dm.StartMode, o => o.MapFrom(sm => sm.StartMode.ToString()));
                })
                .CreateMapper();
    }
}