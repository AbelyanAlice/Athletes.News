using Athletes.News.Core.Infrastructures.DependencyInjection.LifeTime;
using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories.IGeneic;

namespace Athletes.News.Domain.IRepositories;

public interface IDailyNewsRepository : IBaseRepository<DailyNews>, IScoped
{
}
