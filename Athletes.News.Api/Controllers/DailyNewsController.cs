using Athletes.News.Models.DTOs;
using Athletes.News.Models.Requests;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Athletes.News.Api.Controllers;

[Route("News")]
public class DailyNewsController : ControllerBase
{
    private readonly IDailyNewsService _service;
    private readonly IMapper _mapper;
    public DailyNewsController(IDailyNewsService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]DailyNewsRequest request)
    {
        var dto = _mapper.Map<DailyNewsRequest, DailyNewsDto>(request);
        var result = await _service.AddAsync(dto);

        return Ok(result);
    }

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        bool deleteFlag = await _service.Delete(id);
        if (deleteFlag)
        {
            return Ok(id);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _service.GetAllAsync();
        if(result == null)
        {
            return Ok(new List<DailyNewsDto>());
        }
        return Ok(result);
    }

    [HttpGet("getbyid/{id:long}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]long id)
    {
        var result = await _service.GetByIdAsync(id);
        if(result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPut("update/{id:long}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] DailyNewsUpdateRequest request)
    {
        var dto = _mapper.Map<DailyNewsUpdateRequest, DailyNewsDto>(request);
        var result = await _service.UpdateAsync(id, dto);

        return Ok(result);
    }
}
