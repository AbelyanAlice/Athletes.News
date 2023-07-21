using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;

namespace Athletes.News.Services.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _repository;
    private readonly IMapper _mapper;
    public TeamService(ITeamRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(TeamDto dto)
    {
        var entityMapper = _mapper.Map<TeamDto, Team>(dto);
        var entity = await _repository.CreateAsync(entityMapper);
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var team = await _repository.Get(x => x.Id == id).FirstOrDefaultAsync()
                    ?? throw new Exception("Entity not Found");

        return _repository.Delete(team);
    }

    public async Task<List<TeamResponse>> GetAllAsync()
    {
        var team = await _repository.Get().ToListAsync();
        var response = _mapper.Map<List<Team>, List<TeamResponse>>(team);

        return response;
    }

    public async Task<TeamResponse> GetByIdAsync(int id)
    {
        var team = await _repository.Get(x => x.Id == id).FirstOrDefaultAsync()
                    ?? throw new Exception("Entity not Found");

        var response = _mapper.Map<Team, TeamResponse>(team);
        return response;
    }

    

    public async Task<int> UpdateAsync(int id, TeamDto dto)
    {
        var entity = await _repository.Get(x=>x.Id == id).FirstOrDefaultAsync()
                              ?? throw new Exception("Entity not Found");

        var mappedEntity = _mapper.Map(dto, entity);

        var update = _repository.Update(mappedEntity);
        return update.Id;
    }
}
