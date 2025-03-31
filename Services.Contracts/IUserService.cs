using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> PutUserAsync(string id, UserUpdateDto userUpdateDto);
        Task DeleteUserAsync(string id);
    }
}
