using PlatformService.Models;

namespace PlatformService.Data;

public static class PreporationDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        if (context != null) SeedData(context);
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding Data...");

            context.Platforms.AddRange(
                new Platform { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We already have data");
        }
    }
}