namespace Athletes.News.Domain.Entities;

public class DailyNews
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateOnly DateTime { get; set; }
}
