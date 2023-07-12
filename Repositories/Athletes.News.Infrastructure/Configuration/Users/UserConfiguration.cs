using Athletes.News.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athletes.News.Infrastructure.Configuration.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(n => new {n.CountryCode, n.PhoneNumber }).IsUnique();

        builder.HasMany(x => x.UserRoles)
            .WithOne(y => y.User)
            .HasForeignKey(x => x.UserId).IsRequired();
    }
}
