using Athletes.News.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletes.News.Infrastructure.Configuration.DailyNewsConfigurations
{
    public class DailyNewsConfig : IEntityTypeConfiguration<DailyNews>
    {
        public void Configure(EntityTypeBuilder<DailyNews> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
