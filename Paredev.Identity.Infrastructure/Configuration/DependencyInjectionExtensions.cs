using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paredev.Identity.Core.Models;
using Paredev.Identity.Infrastructure.Data;

namespace Paredev.Identity.Infrastructure.Configuration;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddAspNetIdentity();
        services.AddIdentityServer4();
        return services;
    }

    private static void AddIdentityServer4(this IServiceCollection services)
    {
        services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
            .AddConfigurationStore<ApplicationDbContext>(options => 
            {
                options.ConfigureDbContext = builder => 
                    builder.UseInMemoryDatabase("IS4_Tables");
            })
            .AddOperationalStore<ApplicationDbContext>(options => {
                options.ConfigureDbContext = builder =>
                    builder.UseInMemoryDatabase("IS4_Tables");
                options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 3600;
            })
            .AddAspNetIdentity<User>();
    }

    private static void AddAspNetIdentity(this IServiceCollection services)
    {
        services
            .AddDbContext<ApplicationDbContext>(options => 
                options.UseInMemoryDatabase("ParedevIdentity")
            )
            .AddIdentity<User, Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}