using System.Linq.Expressions;

namespace Athletes.News.Domain.IRepositories.IGeneic;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity);

    TEntity Update(TEntity entity);

    bool Delete(TEntity entity);

    Task<TEntity?> GetByIdAsync(long id);

    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? expression = null);
}
