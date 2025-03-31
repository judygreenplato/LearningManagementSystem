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
using System.Security.Claims;

namespace LMS.Presentation.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CourseController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetOneCourse(int id)
        {
            var courseDto = await _serviceManager.CourseService.GetCourseByIdAsync(id);
            return Ok(courseDto);
        }

        [HttpGet("user")]
        public async Task<ActionResult<CourseDto>> GetCourseForCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var courseDto = await _serviceManager.CourseService.GetCourseByUserIdAsync(userId);
            return Ok(courseDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
        {
            var courseDtos = await _serviceManager.CourseService.GetAllCoursesAsync();
            return Ok(courseDtos);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourse(CourseCreateDto dto)
        {
            var createdCourseDto = await _serviceManager.CourseService.CreateCourseAsync(dto);
            return Created();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchCourse(int id, JsonPatchDocument<CourseUpdateDto> patchDocument)
        {
            if (patchDocument is null) return BadRequest();

            var courseToPatch = new CourseUpdateDto(); // Dummy instance for validation
            patchDocument.ApplyTo(courseToPatch, ModelState);

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var updatedCourse = await _serviceManager.CourseService.UpdateCourseAsync(id, patchDocument);

            return Ok(updatedCourse);
        } 

        [HttpPut("{id}")]
        public async Task<ActionResult> PutCourse(int id, CourseUpdateDto courseUpdateDto)
        {
            if (courseUpdateDto is null) return BadRequest();

            var updatedCourse = await _serviceManager.CourseService.PutCourseAsync(id, courseUpdateDto);
            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _serviceManager.CourseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
