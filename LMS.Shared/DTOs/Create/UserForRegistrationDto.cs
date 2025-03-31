using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LMS.Shared.DTOs.Create;

#nullable disable
public record UserForRegistrationDto
{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; init; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string LastName { get; set; }

    public int CourseId { get; init; }

    public string Role { get; init; }
}
