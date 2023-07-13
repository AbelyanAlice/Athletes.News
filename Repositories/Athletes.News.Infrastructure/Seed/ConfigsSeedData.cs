using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Athletes.News.Infrastructure.Seed
{
    public static class ConfigsSeedData
    {
        public static WebApplication SeedAsync(this WebApplication app, IServiceProvider services)
        {
            var context = services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            //Added roles and super admin 
            IdentitySeeder.SeedIdentityUserAndRoles(services.CreateScope().ServiceProvider, context).Wait();

            return app;
        }
    }
}
