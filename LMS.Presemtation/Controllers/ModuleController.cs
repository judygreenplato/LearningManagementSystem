using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Read;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using LMS.Shared.DTOs.Update;

namespace LMS.Presentation.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ModuleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetOneModule(int id)
        {
            var moduleDto = await _serviceManager.ModuleService.GetModuleByIdAsync(id);
            return Ok(moduleDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutModule(int id, ModuleUpdateDto moduleUpdateDto)
        {
            if (moduleUpdateDto is null)
                return BadRequest();

            var updatedModule = await _serviceManager.ModuleService.PutModuleAsync(id, moduleUpdateDto);
            return Ok(updatedModule);
        }

        [HttpPost]
        public async Task<ActionResult> CreateModule(ModuleCreateDto dto)
        {
            var createdModuleDto = await _serviceManager.ModuleService.CreateModuleAsync(dto);
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModule(int id)
        {
            await _serviceManager.ModuleService.DeleteModuleAsync(id);
            return NoContent();
        }
    }
}
