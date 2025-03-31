using LMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace LMS.Presentation.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthService authService;

    public TokenController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("refresh")]
    public async Task<ActionResult> RefreshToken(TokenDto token)
    {
        TokenDto tokenDto = await authService.RefreshTokenAsync(token);
        return Ok(tokenDto);
    }

}
