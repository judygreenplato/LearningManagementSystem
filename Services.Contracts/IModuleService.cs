using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;

namespace Services.Contracts
{
    public interface IModuleService
    {
        Task<ModuleDto> GetModuleByIdAsync(int moduleId);
        Task<ModuleDto> CreateModuleAsync(ModuleCreateDto dto);
        Task<ModuleDto> PutModuleAsync(int id, ModuleUpdateDto moduleUpdateDto);
        Task DeleteModuleAsync(int id);
    }
}