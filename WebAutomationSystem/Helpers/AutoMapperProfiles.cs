using AutoMapper;
using WebAutomationSystem.ApplicationCore.DTOs.JobsChart;
using WebAutomationSystem.ApplicationCore.DTOs.Users;
using WebAutomationSystem.ApplicationCore.Entities.Jobs;
using WebAutomationSystem.ApplicationCore.Entities.Users;

namespace WebAutomationSystem.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUsers, AddUsersDto>().ReverseMap();
            CreateMap<ApplicationUsers, EditUsersDto>().ReverseMap()
                .ForMember(dest => dest.ImageUrl,
                    act => act.Ignore())
                .ForMember(dest => dest.SignatureUrl,
                    act => act.Ignore());

            CreateMap<UserDetailsDto, ApplicationUsers>().ReverseMap();
            CreateMap<JobsChart, AddJobsChartDto>().ReverseMap();
            CreateMap<JobsChart, EditJobsChartDto>().ReverseMap();
        }
    }
}
