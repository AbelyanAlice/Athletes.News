using Athletes.News.Domain.Entities;
using Athletes.News.Domain.IRepositories;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Requests;
using Athletes.News.Models.Response;
using Athletes.News.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Athletes.News.Api.Controllers;

[Route("teams")]
public class TeamController: ControllerBase
{
    private readonly ITeamService _service;
    private readonly IMapper _mapper;
    public TeamController(ITeamService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TeamRequest request)
    {
        var dto = _mapper.Map<TeamRequest, TeamDto>(request);
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute]int id)
    {
        bool deleteFlag = await _service.DeleteAsync(id);
        if (deleteFlag)
        { 
            return Ok(deleteFlag); 
        }
        else 
        { 
            return BadRequest(); 
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _service.GetAllAsync();
        if (result.Count == 0) 
        { 
            return Ok(new List<TeamResponse>()); 
        }
        else return Ok(result);
    }

    [HttpGet("getbyid{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result != null) 
        { 
            return Ok(result); 
        }
        else return BadRequest();

    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute]int id, TeamRequest request)
    {
        var dto = _mapper.Map<TeamRequest, TeamDto>(request);
        var updateResult = await _service.UpdateAsync(id, dto);

        return Ok(updateResult);
    }
}
