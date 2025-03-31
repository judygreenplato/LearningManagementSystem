namespace Services.Contracts;
public interface IServiceManager
{
    IAuthService AuthService { get; }
    ICourseService CourseService { get; }
    IActivityService ActivityService { get; }
    IModuleService ModuleService { get; }
    IUserService UserService { get; }
}