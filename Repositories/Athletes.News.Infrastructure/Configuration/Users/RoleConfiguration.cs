using Athletes.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athletes.News.Infrastructure.Configuration.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(x => x.UserRoles)
            .WithOne(y => y.Role)
            .HasForeignKey(x => x.RoleId).IsRequired();
    }
}
