using Athletes.News.Domain.IRepositories;
using Athletes.News.Infrastructure.Repositories.Generic;
using System.Text.RegularExpressions;

namespace Athletes.News.Infrastructure.Repositories;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    protected GroupRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
