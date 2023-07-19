using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Infrastructure.Repositories.Generic;

namespace Athletes.News.Infrastructure.Repositories;

public class DailyNewsRepository : BaseRepository<DailyNews>, IDailyNewsRepository
{
    public DailyNewsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
