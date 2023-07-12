using Athletes.News.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Athletes.News.Domain.Entities;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string CountryCode { get; set; } = null!;
    public int Status { get; set; }
    public Gender Gender { get; set; }
    public DateTime Age { get; set; }
    public CustomerUser CustomerUser { get; set; } = null!;

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
}
