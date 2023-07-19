namespace Athletes.News.Domain.Entities;

public class DailyNews
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; } = null!;

    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
