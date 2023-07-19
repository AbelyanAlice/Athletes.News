using Athletes.News.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletes.News.Infrastructure.Configuration.Categories
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.DailyNews)
                .WithOne(y => y.Category)
                .HasForeignKey(y => y.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
