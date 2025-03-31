using AutoMapper;
using Domain.Models.Entities;
using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;
namespace LMS.Infrastructure.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserForRegistrationDto, ApplicationUser>().ReverseMap();
        CreateMap<ActivityDto, Activity>().ReverseMap();
        CreateMap<ActivityDocumentDto, ActivityDocument>().ReverseMap();
        CreateMap<ActivityTypeDto, ActivityType>().ReverseMap();
        CreateMap<CourseDto, Course>().ReverseMap();
        CreateMap<CourseDocumentDto, CourseDocument>().ReverseMap();
        CreateMap<ModuleDocumentDto, ModuleDocument>().ReverseMap();
        CreateMap<ModuleDto, Module>().ReverseMap();

        CreateMap<CourseCreateDto, Course>().ReverseMap();
        CreateMap<ModuleCreateDto, Module>().ReverseMap();
        CreateMap<ActivityCreateDto, Activity>().ReverseMap();

        CreateMap<ActivityTypeCreateDto, ActivityType>();
        //CreateMap<CourseDto, CourseCreateDto>().ReverseMap();   

        CreateMap<CourseUpdateDto, Course>().ReverseMap();
        CreateMap<ActivityUpdateDto, Activity>().ReverseMap();
        CreateMap<ModuleUpdateDto, Module>().ReverseMap();

        CreateMap<ApplicationUser, UserDto>().ReverseMap();
        CreateMap<UserUpdateDto, ApplicationUser>().ReverseMap();



    }
}
