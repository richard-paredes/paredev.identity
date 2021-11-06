using System;
using System.Linq;
using Paredev.Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Paredev.Identity.Application;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            // Look for any TODO items.
            if (dbContext.Users.Any())
            {
                return; // DB has been seeded
            }

            PopulateTestData(dbContext);
        }
    }

    public static void PopulateTestData(ApplicationDbContext dbContext)
    {

        dbContext.SaveChanges();
    }
}
