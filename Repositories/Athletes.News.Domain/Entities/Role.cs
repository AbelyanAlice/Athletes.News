using Microsoft.AspNetCore.Identity;

namespace Athletes.News.Domain.Entities;

public class Role : IdentityRole<long>
{
    public ICollection<UserRole> UserRoles { get; set;} = new HashSet<UserRole>();


}
