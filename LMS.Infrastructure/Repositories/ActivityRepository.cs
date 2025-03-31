using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(LmsContext context) : base(context)
        {
        }

        public async Task<Activity?> GetActivityByIdAsync(int activityId, bool trackChanges = false)
        {
            return await FindByCondition(a => a.ActivityId == activityId, trackChanges)
                .Include(a => a.ActivityType)
                .FirstOrDefaultAsync();
        }
    }
}
