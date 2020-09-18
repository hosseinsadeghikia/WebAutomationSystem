using AutoMapper;
using WebAutomationSystem.ApplicationCore.DTOs;
using WebAutomationSystem.ApplicationCore.Entities;

namespace WebAutomationSystem.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUsers, AddUsersDto>();
            CreateMap<ApplicationUsers, EditUsersDto>()
                .ForMember(dest=>dest.ImageUrl,
                    act=>act.Ignore())
                .ForMember(dest=>dest.SignatureUrl,
                    act =>act.Ignore());

            CreateMap<EditUsersDto, ApplicationUsers>();
        }
    }
}
