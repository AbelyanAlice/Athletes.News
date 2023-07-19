using Athletes.News.Domain.IRepositories.IGeneic;
using System.Linq.Expressions;

namespace Athletes.News.Infrastructure.Repositories.Generic;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;
    protected BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? condition)
    {
        IQueryable<TEntity> set = _dbContext.Set<TEntity>();
        if (condition is not null)
        {
            set = set.Where(condition);
        }

        return set;
    }
    public async Task<TEntity?> GetByIdAsync(long id)
    {
        var entity = new object[] { id };
        return await _dbContext.Set<TEntity>().FindAsync(entity);
    }
    public async Task<TEntity> CreateAsync(TEntity item)
    {
        var entityEntry = await _dbContext.AddAsync(item);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }
    public TEntity Update(TEntity item)
    {
        var entityEntry = _dbContext.Set<TEntity>().Update(item);
        _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public bool Delete(TEntity item)
    {
        var del = _dbContext.Set<TEntity>().Remove(item).IsKeySet;
        _dbContext.SaveChangesAsync();
        return del;
    }
}
