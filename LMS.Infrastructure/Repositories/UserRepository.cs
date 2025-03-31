using Domain.Contracts;
using Domain.Models.Entities;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(LmsContext context) : base(context)
        {
        }
        public async Task<ApplicationUser?> GetUserByIdAsync(string userId, bool trackChanges = false)
        {
            return await FindByCondition(c => c.Id == userId, trackChanges).FirstOrDefaultAsync();
        }
    }
}
