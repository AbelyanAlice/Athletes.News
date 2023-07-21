using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Athletes.News.Services.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _repository;
    private readonly IMapper _mapper;
    public GroupService(IGroupRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<int> AddAsync(GroupDto dto)
    {
        var entity = _mapper.Map<GroupDto, Group>(dto);
        var result = await _repository.CreateAsync(entity);

        return result.Id;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _repository.Get(x => x.Id == id).FirstOrDefaultAsync() ??
        throw new Exception("Wrong Id");

        var t = _repository.Delete(result);

        return t;
    }

    public async Task<List<GroupResponse>> GetAllAsync()
    {
        var result = await _repository.Get().ToListAsync();
        var response = _mapper.Map<List<Group>, List<GroupResponse>>(result);

        return response;
    }

    public async Task<GroupResponse> GetByIdAsync(int id)
    {
        var result =  await _repository.Get(x => x.Id == id).FirstOrDefaultAsync()
            ?? throw new Exception("Entity Not Found");

        var response = _mapper.Map<Group, GroupResponse>(result);
        return response;
    }

    public async Task<int> UpdateAsync(int id, GroupDto dto)
    {
        var result = await _repository.Get(x => x.Id == id).FirstOrDefaultAsync()
            ?? throw new Exception("Entity Not Found");

        var mappedResult = _mapper.Map(dto, result);
        var updateResult = _repository.Update(mappedResult);

        return updateResult.Id;
    }
}
