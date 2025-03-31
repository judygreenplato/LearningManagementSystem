using LMS.Shared.DTOs;

namespace LMS.Blazor.Services;

public interface ITokenStorage
{
    Task StoreTokensAsync(string userId, TokenDto tokens);
    Task<TokenDto?> GetTokensAsync(string userId);
    Task<bool> RemoveTokensAsync(string userId);
    Task<string?> GetAccessTokenAsync(string userId);
    Task RefreshTokensAsync(string userId);
}


