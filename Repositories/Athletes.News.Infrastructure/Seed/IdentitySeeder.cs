using Athletes.News.Domain.Entities;
using Athletes.News.Domain.GenericModels;
using Athletes.News.Domain.GenericModels.Enums;
using Athletes.News.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Athletes.News.Infrastructure.Seed
{
    public static class IdentitySeeder
    {
        public static Task SeedIdentityUserAndRoles(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            var superUser = new User
            {
                FirstName = SuperUser.FirstName,
                LastName = SuperUser.LastName,
                Email = SuperUser.Email,
                NormalizedEmail = SuperUser.NormalizedEmail,
                UserName = SuperUser.UserName,
                DateOfLastLogin = DateTime.UtcNow,
                PasswordHash = SuperUser.PasswordHash,
                PhoneNumber = SuperUser.PhoneNumber,
                Status = UserStatus.Active.ToString(),
            };
            var userManager = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<UserManager>();
            var roleManager = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<RoleManager>();
            var roleNames = Enum.GetNames(typeof(Domain.GenericModels.Enums.Role)).ToList();
            foreach (var roleName in roleNames)
            {
                var role = context.Roles.FirstOrDefault(x => x.Name == roleName);
                if (role == null)
                {
                    roleManager.CreateAsync(new Domain.Entities.Role
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    }).Wait();
                }
            }
            var user = userManager.GetUsersInRoleAsync(Roles.SuperAdmin).Result.FirstOrDefault();
            if (!context.Users.Any() || user == null)
            {
                userManager.CreateAsync(superUser, superUser.PasswordHash).Wait();
                user = userManager.GetByEmailAsync(superUser.Email).Result;
            }
            var userRole = userManager.GetRolesAsync(user).Result;
            if (!userRole.Any())
            {
                userManager.AddToRoleAsync(user, Roles.SuperAdmin).Wait();
            }
            return Task.CompletedTask;
        }
    }
}
