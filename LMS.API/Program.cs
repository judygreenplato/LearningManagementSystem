using Domain.Contracts;
using Domain.Models.Entities;
using LMS.API.Extensions;
using LMS.Infrastructure.Data;
using LMS.Infrastructure.Repositories;
using LMS.Presentation;
using LMS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services.Contracts;
using System.Security.Claims;


namespace LMS.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<LmsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("LmsContext") ?? throw new InvalidOperationException("Connection string 'CompaniesContext' not found.")));

        builder.Services.AddControllers(configure =>
        {
            configure.ReturnHttpNotAcceptable = true;
        })
                        .AddNewtonsoftJson(options => {

                            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                        })
                        .AddApplicationPart(typeof(AssemblyReference).Assembly);

        builder.Services.ConfigureOpenApi();
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        builder.Services.ConfigureServiceLayerServices();
        builder.Services.ConfigureRepositories();
        builder.Services.ConfigureJwt(builder.Configuration);
        builder.Services.ConfigureCors();
    //    builder.Services.AddMvc()

    //.AddNewtonsoftJson(options => {

    //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

    //});


        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
        builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IServiceManager, ServiceManager>();

        builder.Services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false;
                opt.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LmsContext>()
                .AddDefaultTokenProviders();

        builder.Services.Configure<PasswordHasherOptions>(options => options.IterationCount = 10000);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            await app.SeedDataAsync();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
