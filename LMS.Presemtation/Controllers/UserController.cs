using Domain.Models.Entities;
using LMS.Shared.DTOs.Create;
using LMS.Shared.DTOs.Read;
using LMS.Shared.DTOs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager, IServiceManager serviceManager)
        {
            _userManager = userManager;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users

                .Select(user => new
                {
                    user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.Role
                })
                .ToListAsync();
            return Ok(users);
        }

        [HttpGet("{targetId}")]
        [Authorize]
        public async Task<IActionResult> GetOneUser(string targetId)
        {
                var user = await _userManager.Users.Where(u => u.Id == targetId).FirstOrDefaultAsync();
                return Ok(user);
        }

        [HttpPut("{targetId}")]
        public async Task<ActionResult> PutUser(string targetId, UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto is null) return BadRequest();

            var updatedUser = await _serviceManager.UserService.PutUserAsync(targetId, userUpdateDto);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await _serviceManager.UserService.DeleteUserAsync(id);
            return NoContent();
        }

        //[HttpGet(]
        //[Authorize]
        //public async Task<IActionResult> GetOneUser([FromQuery] string targetId)
        //{
        //    var user = await _userManager.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        //    return Ok(user);
        //}

    }
}
