using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Athletes.News.Services;

public static class DependancyInjection
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddScoped<PasswordHasher<Type>>();
        service.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
        });

        service.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
