using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Infrastructure.Repositories;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Athletes.News.Services.Services;

public class DailyNewsService : IDailyNewsService
{
    private readonly IDailyNewsRepository _repository;
    private readonly IMapper _mapper;
    public DailyNewsService(IDailyNewsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<long> AddAsync(DailyNewsDto dto)
    {
        var entityMapper = _mapper.Map<DailyNewsDto, DailyNews>(dto);
        var entity = await _repository.CreateAsync(entityMapper);
        return entity.Id;
    }

    public async Task<bool> Delete(long id)
    {
        var dailyNews = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Entity not Found");

        return _repository.Delete(dailyNews);
    }

    public async Task<List<DailyNewsResponse>> GetAllAsync()
    {
        var dailyNews = await _repository.Get().ToListAsync();
        var response = _mapper.Map<List<DailyNews>, List<DailyNewsResponse>>(dailyNews);

        return response;
    }

    public async Task<DailyNewsResponse> GetByIdAsync(long id)
    {
        var dailyNews = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Entity not Found");

        var response = _mapper.Map<DailyNews, DailyNewsResponse>(dailyNews);
        return response;

    }

    public async Task<long> UpdateAsync(long id, DailyNewsDto dto)
    {
        var entity = await _repository.GetByIdAsync(id)
              ?? throw new Exception("Entity not Found");

        var mappedEntity = _mapper.Map(dto, entity);

        var update = _repository.Update(mappedEntity);
        return update.Id;
    }
}
