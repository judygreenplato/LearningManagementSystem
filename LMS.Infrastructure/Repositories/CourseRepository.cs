using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using LMS.Shared.DTOs.Read;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(LmsContext context) : base(context)
        {
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId, bool trackChanges = false)
        {
            return await
                FindByCondition(c => c.CourseId.Equals(courseId), trackChanges)
                .Include(c => c.Modules)
                .ThenInclude(m => m.Activities)
                .ThenInclude(a => a.ActivityType)
                .Include(c => c.Users)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Course>> GetAllCoursesAsync(bool trackChanges = false)
        {
            return await FindAll(trackChanges)
                .Include(c => c.Modules)
                .ThenInclude(m => m.Activities)
                .ToListAsync();
        }

        public async Task<Course?> GetCourseByUserIdAsync(string userId, bool trackChanges = false)
        {
            return await 
                FindByCondition(c => c.Users.Any(u => u.Id == userId), trackChanges)
                .Include(c => c.Modules)
                .ThenInclude(m => m.Activities)
                .ThenInclude(a => a.ActivityType)
                .Include(c => c.Users) 
                .FirstOrDefaultAsync();

        }
    }
}
