using Athletes.News.Domain.Entities;

namespace Athletes.News.Domain.IRepositories;

public interface IDailyNewsManager
{
    void Create(DailyNews dailyNews);
    void Update(DailyNews dailyNews);
    void Delete(DailyNews dailyNews);  
    DailyNews? GetById(long id);
    DailyNews[] GetAllArray();
    List<DailyNews> GetAllList();
}
