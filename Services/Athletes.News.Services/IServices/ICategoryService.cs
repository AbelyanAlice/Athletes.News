using Athletes.News.Core.Infrastructures.DependencyInjection.LifeTime;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;

namespace Athletes.News.Services.IServices;

public interface ICategoryService : IScoped
{
    Task<long> AddAsync(CategoryDto dto);
    Task<long> UpdateAsync(long id, CategoryDto dto);
    Task<bool> DeleteAsync(long id);
    Task<CategoryResponse> GetByIdAsync(long id);
    Task<List<CategoryResponse>> GetAllAsync();
}
