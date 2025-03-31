using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Data;

public class LmsContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public LmsContext(DbContextOptions<LmsContext> options) : base(options)
    {
    }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }

    public DbSet<ActivityDocument> ActivityDocuments { get; set; }
    public DbSet<CourseDocument> CourseDocuments { get; set; }
    public DbSet<ModuleDocument> ModuleDocuments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                CourseId = 1,
                Name = "Fullstack.NET 2025",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 01),
                EndDate = new DateTime(2025, 01, 29),
                CourseDocuments = null,
                Modules = new List<Module>()
            },
            new Course
            {
                CourseId = 2,
                Name = "Frontend 2025",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 01),
                EndDate = new DateTime(2025, 01, 29),
                CourseDocuments = null,
                Modules = new List<Module>()
            });
        modelBuilder.Entity<Module>().HasData(
            new Module
            {
                ModuleId = 1,
                Name = "C# - basics",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 22),
                EndDate = new DateTime(2025, 01, 26),
                CourseId = 1,
                ModuleDocuments = null,
                Activities = new List<Activity>()
            },
            new Module
            {
                ModuleId = 2,
                Name = "HTML - basics",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 22),
                EndDate = new DateTime(2025, 01, 26),
                CourseId = 2,
                ModuleDocuments = null,
                Activities = new List<Activity>()
            },
            new Module
            {
                ModuleId = 3,
                Name = "Blazor - basics",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 27),
                EndDate = new DateTime(2025, 01, 29),
                CourseId = 2,
                ModuleDocuments = null,
                Activities = new List<Activity>()
            });
        modelBuilder.Entity<ActivityType>().HasData(
            new ActivityType
            {
                ActivityTypeId = 1,
                Type = "Föreläsning"
            },
            new ActivityType
            {
                ActivityTypeId = 2,
                Type = "Övning"
            },
            new ActivityType
            {
                ActivityTypeId = 3,
                Type = "Inlämning"
            },
            new ActivityType
            {
                ActivityTypeId = 4,
                Type = "Gruppuppgift"
            });        
        modelBuilder.Entity<Activity>().HasData(
            new Activity
            {
                ActivityId = 1,
                Name = "Föreläsning - C#",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 22, 11, 0, 0),
                EndDate = new DateTime(2025, 01, 22, 15, 0, 0),
                ActivityTypeId = 1,
                ModuleId = 1,
                ActivityDocument = null
            },
            new Activity
            {
                ActivityId = 2,
                Name = "Föreläsning - Blazor",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 23, 11, 0, 0),
                EndDate = new DateTime(2025, 01, 25, 15, 0, 0),
                ActivityTypeId = 1,
                ModuleId = 1,
                ActivityDocument = null
            },
            new Activity
            {
                ActivityId = 3,
                Name = "Föreläsning - HTML",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 22, 11, 0, 0),
                EndDate = new DateTime(2025, 01, 23, 15, 0, 0),
                ActivityTypeId = 1,
                ModuleId = 2,
                ActivityDocument = null
            },
            new Activity
            {
                ActivityId = 4,
                Name = "Föreläsning - CSS",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 24, 11, 0, 0),
                EndDate = new DateTime(2025, 01, 26, 15, 0, 0),
                ActivityTypeId = 1,
                ModuleId = 2,
                ActivityDocument = null
            },
            new Activity
            {
                ActivityId = 5,
                Name = "Föreläsning - JavaScript",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 27, 11, 0, 0),
                EndDate = new DateTime(2025, 01, 29, 15, 0, 0),
                ActivityTypeId = 1,
                ModuleId = 2,
                ActivityDocument = null
            },
            new Activity
            {
                ActivityId = 6,
                Name = "Föreläsning - Blazor",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 27, 11, 0, 0),
                EndDate = new DateTime(2025, 01, 29, 15, 0, 0),
                ActivityTypeId = 1,
                ModuleId = 3,
                ActivityDocument = null
            },
            new Activity
            {
                ActivityId = 7,
                Name = "Övning - Blazor",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                StartDate = new DateTime(2025, 01, 23, 11, 0, 0),
                EndDate = new DateTime(2025, 01, 25, 15, 0, 0),
                ActivityTypeId = 2,
                ModuleId = 3,
                ActivityDocument = null
            }
        );
    }
}
