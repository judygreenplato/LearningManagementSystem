using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Entities;
using LMS.Shared.DTOs.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Presentation.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPut("updatePassword")]
    [Authorize]
    public async Task<IActionResult> UpdatePassword([FromBody] PasswordUpdateDto reqBody)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Get currently authenticated user
        ApplicationUser user = await _userManager.GetUserAsync(User);

        if (user == null) return Unauthorized();

        // Update user's password
        var result = await _userManager
            .ChangePasswordAsync(user, reqBody.CurrentPassword, reqBody.NewPassword);

        if (!result.Succeeded) return BadRequest();

        return NoContent();
    }
}
