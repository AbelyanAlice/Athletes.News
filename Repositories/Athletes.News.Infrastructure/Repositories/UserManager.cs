using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletes.News.Infrastructure.Repositories;

public sealed class UserManager : UserManager<User>, IUserManager
{
    private readonly ILogger<UserManager> _logger;
    public UserManager(
        IUserStore<User> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher,
        IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _logger = logger;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return (await Users
            .Where(x => x.Email == email)
            .SingleOrDefaultAsync())!;
    }
}
