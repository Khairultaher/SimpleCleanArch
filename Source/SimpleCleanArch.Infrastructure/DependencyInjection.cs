using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleCleanArch.Application.Common.Constants;
using SimpleCleanArch.Application.Common.Interfaces;
using SimpleCleanArch.Application.Common.Security;
using SimpleCleanArch.Infrastructure.Identity;
using SimpleCleanArch.Infrastructure.Persistence;
using SimpleCleanArch.Infrastructure.Services;
using System.Text;

namespace SimpleCleanArch.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IDomainEventService, DomainEventService>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IIdentityService, IdentityService>();
        //services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        services.AddAuthentication().AddIdentityServerJwt();

        //hosted services
        services.AddHostedService<DatabaseSeedingService>();
        //services.AddTransient<ApplicationDbContextSeed>();

        #region Configure Token Based Authentication 

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Constants.JwtToken.Issuer,
                ValidateAudience = true,
                ValidAudience = Constants.JwtToken.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JwtToken.SigningKey))
            };
        });
        #endregion

        #region Configure Authorization with Policy
        services.AddAuthorization(options =>
        {
            options.AddPolicy("HRAdmin", policy => policy.RequireClaim("Depertment", "HR")
                                                      .RequireRole("Admin"));

            options.AddPolicy("AccountsAdmin", policy => policy.RequireClaim("Depertment", "Accounts")
                                                     .RequireRole("Admin"));

            options.AddPolicy("SysAdmin", policy => policy.RequireRole("SysAdmin"));

            options.AddPolicy("HRManagerOnly", policy => policy
                    .RequireClaim("Department", "HR")
                    .RequireClaim("Manager")
                    .Requirements.Add(new HRManagerProbationRequirement(3)));
        });

        //services.AddHttpClient("OurWebAPI", client =>
        //{
        //    client.BaseAddress = new Uri("https://localhost:44336/");
        //var httpClient = httpClientFactory.CreateClient("OurWebAPI");
        //});

        #endregion

        return services;
    }
}

