using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Entities;
using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;
using Microsoft.AspNetCore.JsonPatch;
using Services.Contracts;

namespace LMS.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CourseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CourseDto> GetCourseByIdAsync(int courseId)
        {
            Course? course = await _uow.CourseRepository.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                // Do something
            }
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _uow.CourseRepository.GetAllCoursesAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> CreateCourseAsync(CourseCreateDto dto)
        {
            Course course = _mapper.Map<Course>(dto);

            _uow.CourseRepository.Create(course);

            await _uow.CompleteAsync();

            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> UpdateCourseAsync(int id, JsonPatchDocument<CourseUpdateDto> patchDocument)
        {
            var courseToPatch = await _uow.CourseRepository.GetCourseByIdAsync(id, true);
            if (courseToPatch == null) throw new KeyNotFoundException($"{id} not found.");

            var course = _mapper.Map<CourseUpdateDto>(courseToPatch);
            patchDocument.ApplyTo(course);

            _mapper.Map(course, courseToPatch);
            await _uow.CompleteAsync();

            return _mapper.Map<CourseDto>(courseToPatch);
        }

        public async Task DeleteCourseAsync(int id)
        {
            var courseToDelete = await _uow.CourseRepository.GetCourseByIdAsync(id, true);
            if (courseToDelete == null) throw new KeyNotFoundException($"{id} not found.");
            _uow.CourseRepository.Delete(courseToDelete);

            await _uow.CompleteAsync();
        }

        public async Task<CourseDto> GetCourseByUserIdAsync(string userId)
        {
            var course = await _uow.CourseRepository.GetCourseByUserIdAsync(userId);
            if (course == null)
            {
                throw new KeyNotFoundException($"not found");
            }
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> PutCourseAsync(int id, CourseUpdateDto course)
        {
            var courseToUpdate = await _uow.CourseRepository.GetCourseByIdAsync(id, true);
            if (courseToUpdate == null) throw new KeyNotFoundException($"{id} not found.");

            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;
            courseToUpdate.StartDate = course.StartDate;
            courseToUpdate.EndDate = course.EndDate;

            await _uow.CompleteAsync();

            return _mapper.Map<CourseDto>(courseToUpdate);
        }
    }
}
