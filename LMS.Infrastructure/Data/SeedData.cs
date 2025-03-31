using Bogus;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Infrastructure.Data;

public static class SeedData
{
    private static UserManager<ApplicationUser> userManager = null!;
    private static RoleManager<IdentityRole> roleManager = null!;
    private const string adminRole = "Teacher";
    private const string studentRole = "Student";

    public static async Task SeedDataAsync(this IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var db = serviceProvider.GetRequiredService<LmsContext>();

            if (await db.Users.AnyAsync()) return;

            userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>() ?? throw new ArgumentNullException(nameof(userManager));
            roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>() ?? throw new ArgumentNullException(nameof(roleManager));

            try
            {
                var roleNames = new[] { adminRole, studentRole };
                await CreateRolesAsync(roleNames);
                await GenerateUsersAsync(5);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    private static async Task CreateRolesAsync(string[] roleNames)
    {
        foreach (var roleName in roleNames)
        {
            if (await roleManager.RoleExistsAsync(roleName)) continue;
            var role = new IdentityRole { Name = roleName };
            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
        }
    }

    private static async Task GenerateUsersAsync(int nrOfUsers)
    {
        var faker = new Faker<ApplicationUser>("sv").Rules((f, e) =>
        {
            e.Email = f.Person.Email;
            e.UserName = f.Person.Email;
            e.FirstName = f.Person.FirstName;
            e.LastName = f.Person.LastName;
            e.CourseId = 1;
            e.Role = "Student";
        });

        var users = faker.Generate(nrOfUsers);

        //ToDo: Add to user.secrets
        var passWord = "BytMig123!";
        if (string.IsNullOrEmpty(passWord))
            throw new Exception("password not found");

        foreach (var user in users)
        {
            var result = await userManager.CreateAsync(user, passWord);
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
        }

        for (var i = 0; i < users.Count; i++)
        {
            IdentityResult result;
            if (i == 0)
            {
                result = await userManager.AddToRoleAsync(users[i], adminRole);
                // Show that the first user is a teacher
                users[i].Role = "Teacher";
            }
            else
            {
                result = await userManager.AddToRoleAsync(users[i], studentRole);
            }
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
        }
    }

    private static async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
    {
        if (!await userManager.IsInRoleAsync(user, roleName))
        {
            var result = await userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded) throw new Exception(string.Join(", ", result.Errors.Select(x => "Code " + x.Code + " Description" + x.Description)));
        }
    }
}



