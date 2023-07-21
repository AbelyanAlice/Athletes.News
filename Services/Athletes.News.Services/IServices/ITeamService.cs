using Athletes.News.Core.Infrastructures.DependencyInjection.LifeTime;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;

namespace Athletes.News.Services.IServices;

public interface ITeamService : IScoped
{
    Task<int> AddAsync(TeamDto dto);
    Task<bool> DeleteAsync(int id);
    Task<List<TeamResponse>> GetAllAsync();
    Task<TeamResponse> GetByIdAsync(int id);
    Task<int> UpdateAsync(int id, TeamDto dto);
}
