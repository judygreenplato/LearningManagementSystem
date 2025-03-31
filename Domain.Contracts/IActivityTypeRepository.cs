using Domain.Models.Entities;

namespace LMS.Infrastructure.Repositories
{
    public interface IActivityTypeRepository
    {
        Task<List<ActivityType>> GetAllActivityTypesAsync(bool trackChanges = false);
    }
}