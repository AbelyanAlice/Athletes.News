using Athletes.News.Models.DTOs;
using Athletes.News.Models.Requests;
using Athletes.News.Models.Response;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Athletes.News.Api.Controllers;

[Route("Groups")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _service;
    private readonly IMapper _mapper;

    public GroupController(IGroupService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] GroupRequest request)
    {
        var dto = _mapper.Map<GroupRequest, GroupDto>(request);
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        bool deleteFlag = await _service.DeleteAsync(id);
        if (deleteFlag) 
        { return Ok(deleteFlag); }
        else { return BadRequest(); }
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _service.GetAllAsync();
        if (result.Count == 0) { return Ok(new List<GroupResponse>()); }
        else return Ok(result);
    }

    [HttpGet("getbyid/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result != null) { return Ok(result); }
        else return BadRequest();
    }

    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, GroupRequest request)
    {
        var dto = _mapper.Map<GroupRequest, GroupDto>(request);
        var updateResult = await _service.UpdateAsync(id, dto);

        return Ok(updateResult);
    }
}
