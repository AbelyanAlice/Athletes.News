using Athletes.News.Infrastructure;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Requests;
using Athletes.News.Models.Response;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Athletes.News.Api.Controllers;

[Route("categories")]
public class CategoryController : ControllerBase
{
    
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CategoryRequest request)
    {
        var dto = _mapper.Map<CategoryRequest, CategoryDto>(request);
        var result = await _service.AddAsync(dto);

        return Ok(result);
    }

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        bool deleteFlag = await _service.DeleteAsync(id);
        if (deleteFlag) { return Ok(deleteFlag); }
        else { return BadRequest(); }
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _service.GetAllAsync();
        if (result.Count == 0) { return Ok(new List<CategoryResponse>()); }
        else return Ok(result);
    }

    [HttpGet("getbyid/{id:long}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result != null) { return Ok(result); }
        else return BadRequest();
    }

    [HttpPut("update/{id:long}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, CategoryRequest request)
    {
        var dto = _mapper.Map<CategoryRequest, CategoryDto>(request);
        var updateResult = await _service.UpdateAsync(id, dto);

        return Ok(updateResult);
    }
}
