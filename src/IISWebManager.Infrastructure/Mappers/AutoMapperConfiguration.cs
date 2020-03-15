using AutoMapper;
using IISWebManager.Application.DTO.ApplicationPools;
using IISWebManager.Application.DTO.Applications;
using IISWebManager.Infrastructure.Utils;
using Microsoft.Web.Administration;
using App = Microsoft.Web.Administration.Application;

namespace IISWebManager.Infrastructure.Mappers
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetMapper()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ApplicationPool, ApplicationPoolGetDto>()
                        .ForMember(dm => dm.Status, o => o.MapFrom(sm => sm.State))
                        .ForMember(dm => dm.Identity, o => o.MapFrom(sm => sm.ProcessModel.IdentityType))
                        .ForMember(dm => dm.Applications,
                            o => o.MapFrom(sm => ApplicationPoolUtils.GetNumberOfApplicationPoolApplications(sm.Name)));

                    cfg.CreateMap<ApplicationPool, ApplicationPoolEditablePropertiesDto>()
                        .ForMember(dm => dm.Identity, o => o.MapFrom(sm => sm.ProcessModel.IdentityType));

                    cfg.CreateMap<App, ApplicationGetDto>()
                        .ForMember(dm => dm.Name, o => o.MapFrom(sm => ApplicationUtils.ConvertPathToName(sm.Path)))
                        .ForMember(dm => dm.PhysicalPath,
                            o => o.MapFrom(sm => sm.VirtualDirectories["/"].PhysicalPath))
                        .ForMember(dm => dm.ApplicationPoolStatus,
                            o => o.MapFrom(sm =>
                                ApplicationPoolUtils.GetApplicationPoolStatus(sm.ApplicationPoolName)));
                })
                .CreateMapper();
    }
}