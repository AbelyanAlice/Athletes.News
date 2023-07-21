using Athletes.News.Domain.Entities;
using Athletes.News.Models.DTOs;
using Athletes.News.Models.Requests;
using Athletes.News.Models.Response;
using AutoMapper;

namespace Athletes.News.Services.Mapping;

public class ApplicationMapping : Profile
{
    public ApplicationMapping()
    {
        CreateMap<DailyNewsDto, DailyNews>();
        CreateMap<DailyNews, DailyNewsResponse>();
        CreateMap<DailyNewsRequest, DailyNewsDto>();
        CreateMap<DailyNewsUpdateRequest, DailyNewsDto>();
        CreateMap<DailyNewsDto, DailyNewsResponse>();
        CreateMap<DailyNewsDto, DailyNewsResponse>();

        CreateMap<CategoryDto, Category>();
        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequest, CategoryDto>();

        CreateMap<GroupDto, Group>();
        CreateMap<Group, GroupResponse>();
        CreateMap<GroupRequest, GroupDto>();

        CreateMap<TeamDto, Team>();
        CreateMap<Team, TeamResponse>();
        CreateMap<TeamRequest, TeamDto>();

    }
}