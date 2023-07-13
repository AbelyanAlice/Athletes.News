using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;

namespace Athletes.News.Infrastructure.Repositories;

public class DailyNewsManager : IDailyNewsManager
{
    private ApplicationDbContext _context;
    public DailyNewsManager(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(DailyNews dailyNews)
    {
        _context.DailyNews.Add(dailyNews);
        _context.SaveChanges();
    }

    public void Delete(DailyNews dailyNews)
    {
        _context.DailyNews.Remove(dailyNews);
        _context.SaveChanges();
    }

    public DailyNews[] GetAllArray()
    {
        return _context.DailyNews.ToArray();
    }

    public List<DailyNews> GetAllList()
    {
        return _context.DailyNews.ToList();
    }

    public DailyNews? GetById(long id)
    {
        return _context.DailyNews.FirstOrDefault(x => x.Id == id);
    }

    public void Update(DailyNews dailyNews)
    {
        _context.DailyNews.Update(dailyNews);
        _context.SaveChanges();
    }
}
