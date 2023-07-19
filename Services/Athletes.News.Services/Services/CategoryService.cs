using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Response;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Athletes.News.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<long> AddAsync(CategoryDto dto)
    {
        var entityMapper = _mapper.Map<CategoryDto, Category>(dto);
        var entity = await _repository.CreateAsync(entityMapper);

        return entity.Id;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
        {
            throw new Exception("Wrong Id");
        }

        return _repository.Delete(result);
    }

    public async Task<List<CategoryResponse>> GetAllAsync()
    {
        var category = await _repository.Get().ToListAsync();
        var response = _mapper.Map<List<Category>, List<CategoryResponse>>(category);

        return response;
    }

    public async Task<CategoryResponse> GetByIdAsync(long id)
    {
        var category = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Entity Not Found");

        var response = _mapper.Map<Category, CategoryResponse>(category);
        return response;
    }

    public async Task<long> UpdateAsync(long id, CategoryDto dto)
    {
        var category = await _repository.GetByIdAsync(id)
            ?? throw new Exception("Entity Not Found");

        var mappedResult = _mapper.Map(dto, category);
        var updateResult = _repository.Update(mappedResult);

        return updateResult.Id;

    }
}
