using Athletes.News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Athletes.News.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<User, Role, long,
    IdentityUserClaim<long>, UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
    {

    }

    public DbSet<CustomerUser>? CustomerUsers { get; set; }

    public DbSet<RefreshToken>? RefreshTokens { get; set; }

    public DbSet<DailyNews>? DailyNews { get; set; }

    public DbSet<Category>? Categories { get; set; }


}