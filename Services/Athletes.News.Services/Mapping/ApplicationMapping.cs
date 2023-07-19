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
        CreateMap<CategoryDto, Category>();
        CreateMap<DailyNews, DailyNewsResponse>();
        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryRequest, CategoryDto>();
        CreateMap<DailyNewsRequest, DailyNewsDto>();
        CreateMap<DailyNewsUpdateRequest, DailyNewsDto>();
        CreateMap<DailyNewsDto, DailyNewsResponse>();
    }
}