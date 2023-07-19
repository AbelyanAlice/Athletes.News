using Athletes.News.Core.Infrastructures.DependencyInjection.LifeTime;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;

namespace Athletes.News.Services.IServices;

public interface IDailyNewsService : IScoped
{
    Task<long> AddAsync(DailyNewsDto dto);
    Task<long> UpdateAsync(long id, DailyNewsDto dto);
    Task<bool> Delete(long id);
    Task<DailyNewsResponse> GetByIdAsync(long id);
    Task<List<DailyNewsResponse>> GetAllAsync();
}
