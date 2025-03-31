using Domain.Models.Entities;

namespace Domain.Contracts
{
    public interface IActivityRepository
    {
        Task<Activity?> GetActivityByIdAsync(int activityId, bool trackChanges = false);
        void Create(Activity entity);
        void Update(Activity entity);
        void Delete(Activity entity);
    }
}