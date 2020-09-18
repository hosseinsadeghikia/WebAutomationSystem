using AutoMapper;
using WebAutomationSystem.ApplicationCore.DTOs;
using WebAutomationSystem.ApplicationCore.Entities;

namespace WebAutomationSystem.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUsers, UsersDto>().ReverseMap();
        }
    }
}
