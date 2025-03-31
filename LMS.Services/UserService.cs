using AutoMapper;
using Domain.Contracts;
using Domain.Models.Entities;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IUnitOfWork uow, IMapper mapper)
        {
            _userManager = userManager;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDto> PutUserAsync(string id, UserUpdateDto userUpdateDto)
        {
            var userToUpdate = await _uow.UserRepository.GetUserByIdAsync(id, true);
            if (userToUpdate == null) throw new KeyNotFoundException($"{id} not found.");

            userToUpdate.CourseId = userUpdateDto.CourseId;
            userToUpdate.Email = userUpdateDto.Email;
            userToUpdate.FirstName = userUpdateDto.FirstName;
            userToUpdate.LastName = userUpdateDto.LastName;
            userToUpdate.Role = userUpdateDto.Role;

            await _userManager.RemoveFromRolesAsync(userToUpdate, ["Teacher", "Student"]);

            await _userManager.AddToRoleAsync(userToUpdate, userToUpdate.Role);

            await _uow.CompleteAsync();

            return _mapper.Map<UserDto>(userToUpdate);
        }

        public async Task DeleteUserAsync(string id)
        {
            var userToDelete = await _uow.UserRepository.GetUserByIdAsync(id, true);
            if (userToDelete == null) throw new KeyNotFoundException($"{id} not found.");
            _uow.UserRepository.Delete(userToDelete);

            await _uow.CompleteAsync();
        }
    }
}
