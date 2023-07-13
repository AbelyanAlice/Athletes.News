using Athletes.News.Domain.Enums;
using Athletes.News.Infrastructure.Configuration.Users;
using Microsoft.AspNetCore.Identity;

namespace Athletes.News.Domain.Entities;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? CountryCode { get; set; }
    public string Status { get; set; }=null!;
    public Gender Gender { get; set; }
    public DateTime Age { get; set; }
    public DateTime DateOfLastLogin { get; set; }
    public CustomerUser CustomerUser { get; set; } = null!;

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}
