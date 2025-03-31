using LMS.Infrastructure.Repositories;

namespace Domain.Contracts;

public interface IUnitOfWork
{
    IActivityRepository ActivityRepository { get; }
    IActivityTypeRepository ActivityTypeRepository { get; }
    ICourseRepository CourseRepository { get; }
    IModuleRepository ModuleRepository { get; }
    IUserRepository UserRepository { get; }

    Task CompleteAsync();
}