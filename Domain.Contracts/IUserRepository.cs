using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserByIdAsync(string userId, bool trackChanges = false);
        void Delete(ApplicationUser entity);
    }
}
