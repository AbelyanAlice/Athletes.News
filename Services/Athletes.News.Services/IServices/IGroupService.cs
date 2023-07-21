using Athletes.News.Core.Infrastructures.DependencyInjection.LifeTime;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;

namespace Athletes.News.Services.IServices;

public interface IGroupService : IScoped
{
    Task<int> AddAsync(GroupDto dto);
    Task<bool> DeleteAsync(int id);
    Task<List<GroupResponse>> GetAllAsync();
    Task<GroupResponse> GetByIdAsync(int id);
    Task<int> UpdateAsync(int id, GroupDto dto);

}
