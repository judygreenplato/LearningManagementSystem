namespace LMS.Blazor.Client.Models;

// Add properties to this class and update the server and client AuthenticationStateProviders
// to expose more information about the authenticated user to the client.
// Todo: Add role! 
public class UserInfo
{
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }

}
