using AutoMapper;
using Domain.Contracts;
using LMS.Infrastructure.Data;

namespace LMS.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LmsContext _context;
    private readonly Lazy<IActivityRepository> _activityRepository;
    private readonly Lazy<IActivityTypeRepository> _activityTypeRepository;
    private readonly Lazy<IModuleRepository> _moduleRepository;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<IUserRepository> _userRepository;

    public IActivityRepository ActivityRepository => _activityRepository.Value;
    public IActivityTypeRepository ActivityTypeRepository => _activityTypeRepository.Value;
    public IModuleRepository ModuleRepository => _moduleRepository.Value;
    public ICourseRepository CourseRepository => _courseRepository.Value;
    public IUserRepository UserRepository => _userRepository.Value;


    public UnitOfWork(LmsContext context)
    {
        _context = context;
        _activityRepository = new Lazy<IActivityRepository>(() => new ActivityRepository(_context));
        _activityTypeRepository = new Lazy<IActivityTypeRepository>(() => new ActivityTypeRepository(_context));
        _moduleRepository = new Lazy<IModuleRepository>(() => new ModuleRepository(_context));
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(_context));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}
