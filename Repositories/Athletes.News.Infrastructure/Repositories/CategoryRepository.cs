using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Athletes.News.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
