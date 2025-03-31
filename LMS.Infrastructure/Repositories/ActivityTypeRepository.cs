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
    public class ActivityTypeRepository : RepositoryBase<ActivityType>, IActivityTypeRepository
    {
        public ActivityTypeRepository(LmsContext context) : base(context)
        {
        }


        public async Task<List<ActivityType>> GetAllActivityTypesAsync(bool trackChanges = false)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }
}
