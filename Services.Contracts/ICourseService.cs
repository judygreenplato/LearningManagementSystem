using Domain.Models.Entities;
using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;
using Microsoft.AspNetCore.JsonPatch;

namespace Services.Contracts
{
    public interface ICourseService
    {
        Task<CourseDto> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> CreateCourseAsync(CourseCreateDto dto);
        Task<CourseDto> UpdateCourseAsync(int id, JsonPatchDocument<CourseUpdateDto> patchDocument);
        Task DeleteCourseAsync(int id);
        Task<CourseDto> GetCourseByUserIdAsync(string userId);
        Task<CourseDto> PutCourseAsync(int id, CourseUpdateDto courseUpdateDto);
    }
}