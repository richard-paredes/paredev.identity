using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Paredev.Identity.Infrastructure.Data;

public static class IdentityConfiguration
{
    public static void DbContextConfiguration(ConfigurationStoreOptions options)
    {
        options.ConfigureDbContext = builder => builder.UseInMemoryDatabase("IdentityServerTables");
    }
}