namespace Athletes.News.Models.DTOs;

public class DailyNewsDto
{
    public string Title { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; } = null!;
    public long CategoryId { get; set; }

}
