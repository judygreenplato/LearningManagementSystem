using Domain.Models.Entities;

namespace Domain.Contracts
{
    public interface IModuleRepository
    {
        Task<Module?> GetModuleByIdAsync(int moduleId, bool trackChanges = false);
        void Create(Module entity);
        void Update(Module entity);
        void Delete(Module entity);
    }
}