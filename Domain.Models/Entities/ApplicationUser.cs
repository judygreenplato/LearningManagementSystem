using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Entities;

//Separate ApplicationUser between projects
//Setup relationship with EF here!
public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int? CourseId { get; set; }
    public Course? Course { get; set; }

    public string Role { get; set; }

}