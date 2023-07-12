using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Athletes.News.Infrastructure.Repositories;

public class RoleManager : RoleManager<Role>, IRoleManager
{
    private readonly ILogger _logger;
    public RoleManager(IRoleStore<Role> store, 
        IEnumerable<IRoleValidator<Role>> roleValidators, 
        ILookupNormalizer keyNormalizer, 
        IdentityErrorDescriber errors, 
        ILogger<RoleManager<Role>> logger) 
        : base(store, roleValidators, keyNormalizer, errors, logger)
    {
        _logger = logger;
    }
}
