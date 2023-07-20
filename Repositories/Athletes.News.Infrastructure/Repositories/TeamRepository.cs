using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Infrastructure.Repositories.Generic;

namespace Athletes.News.Infrastructure.Repositories;

public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
    public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
