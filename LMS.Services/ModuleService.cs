using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using AutoMapper;
using Domain.Models.Entities;
using Services.Contracts;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Update;

namespace LMS.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ModuleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ModuleDto> GetModuleByIdAsync(int moduleId)
        {
            Module? module = await _uow.ModuleRepository.GetModuleByIdAsync(moduleId);
            return _mapper.Map<ModuleDto>(module);
        }

        public async Task<ModuleDto> CreateModuleAsync(ModuleCreateDto dto)
        {
            Module module = _mapper.Map<Module>(dto);

            _uow.ModuleRepository.Create(module);

            await _uow.CompleteAsync();

            return _mapper.Map<ModuleDto>(module);
        }

        public async Task<ModuleDto> PutModuleAsync(int id, ModuleUpdateDto moduleUpdateDto)
        {
            var moduleToUpdate = await _uow.ModuleRepository.GetModuleByIdAsync(id, true);

            if (moduleToUpdate == null)
                throw new KeyNotFoundException($"Module with ID {id} not found.");

            moduleToUpdate.Name = moduleUpdateDto.Name;
            moduleToUpdate.Description = moduleUpdateDto.Description;
            moduleToUpdate.StartDate = moduleUpdateDto.StartDate;
            moduleToUpdate.EndDate = moduleUpdateDto.EndDate;

            await _uow.CompleteAsync();

            return _mapper.Map<ModuleDto>(moduleToUpdate);
        }

        public async Task DeleteModuleAsync(int id)
        {
            var courseToDelete = await _uow.ModuleRepository.GetModuleByIdAsync(id, true);
            if (courseToDelete == null) throw new KeyNotFoundException($"{id} not found.");
            _uow.ModuleRepository.Delete(courseToDelete);

            await _uow.CompleteAsync();
        }
    }
}
