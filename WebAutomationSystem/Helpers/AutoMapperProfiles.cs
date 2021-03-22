using AutoMapper;
using WebAutomationSystem.ApplicationCore.DTOs.Users;
using WebAutomationSystem.ApplicationCore.Entities.Users;

namespace WebAutomationSystem.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUsers, AddUsersDto>().ReverseMap();
            CreateMap<ApplicationUsers, EditUsersDto>()
                .ForMember(dest => dest.ImageUrl,
                    act => act.Ignore())
                .ForMember(dest => dest.SignatureUrl,
                    act => act.Ignore());

            CreateMap<EditUsersDto, ApplicationUsers>();
            CreateMap<UserDetailsDto, ApplicationUsers>().ReverseMap();
        }
    }
}
