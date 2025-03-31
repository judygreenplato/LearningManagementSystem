using Domain.Contracts;
using Domain.Models.Configuration;
using LMS.Infrastructure.Repositories;
using LMS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Contracts;
using System.Text;

namespace LMS.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        //ToDo: Set stricter rules!
        services.AddCors(builder =>
        {
            builder.AddPolicy("AllowAll", p =>
                p.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                );
        });
    }

    public static void ConfigureServiceLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddLazy<IAuthService>();
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }   

    public static void ConfigureOpenApi(this IServiceCollection services) =>
       services.AddEndpointsApiExplorer()
               .AddSwaggerGen(setup =>
               {
                   setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                   {
                       In = ParameterLocation.Header,
                       Description = "Place to add JWT with Bearer",
                       Name = "Authorization",
                       Type = SecuritySchemeType.Http,
                       Scheme = "Bearer"
                   });

                   setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                   {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                   });
               });


    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration["secretkey"];
        ArgumentNullException.ThrowIfNull(secretKey, nameof(secretKey));

        var jwtSettings = configuration.GetSection("JwtSettings");
        ArgumentNullException.ThrowIfNull(nameof(jwtSettings));

        var jwtConfig = new JwtConfiguration();
        jwtSettings.Bind(jwtConfig);

        services.Configure<JwtConfiguration>(options =>
        {
            options.Issuer = jwtConfig.Issuer;
            options.Audience = jwtConfig.Audience;
            options.Expires = jwtConfig.Expires;
            options.SecretKey = secretKey;
        });


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
               .AddJwtBearer(options =>
               {

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       ValidIssuer = jwtSettings["Issuer"],
                       ValidAudience = jwtSettings["Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                   };
               });
    }
}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLazy<TService>(this IServiceCollection services) where TService : class
    {
        return services.AddScoped(provider => new Lazy<TService>(() => provider.GetRequiredService<TService>()));
    }
}
