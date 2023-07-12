using Athletes.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athletes.News.Infrastructure.Configuration.Users;

public class CustomerUserConfiguration : IEntityTypeConfiguration<CustomerUser>
{
    public void Configure(EntityTypeBuilder<CustomerUser> builder)
    {
        builder.HasOne(n=>n.User)
            .WithOne(x=>x.CustomerUser)
            .HasForeignKey<CustomerUser>(x=>x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
