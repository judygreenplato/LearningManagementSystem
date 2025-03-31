using LMS.Shared.DTOs;
using LMS.Shared.DTOs.Create;
using Microsoft.AspNetCore.Identity; ////ToDo Check version

namespace Services.Contracts;

public interface IAuthService
{
    Task<TokenDto> CreateTokenAsync(bool expireTime);
    Task<TokenDto> RefreshTokenAsync(TokenDto token);
    Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto registrationDto);
    Task<bool> ValidateUserAsync(UserForAuthDto userForAuthDto);
}