using LMS.Shared.DTOs;
using LMS.Shared.DTOs.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace LMS.Presentation.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IServiceManager serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser(UserForRegistrationDto registrationDto)
    {
        var result = await serviceManager.AuthService.RegisterUserAsync(registrationDto);
        return result.Succeeded ? StatusCode(StatusCodes.Status201Created) : BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Authenticate(UserForAuthDto userForAuthDto)
    {

        if (!await serviceManager.AuthService.ValidateUserAsync(userForAuthDto))
            return Unauthorized();

        TokenDto token = await serviceManager.AuthService.CreateTokenAsync(expireTime: true);

        return Ok(token);
    }

}
