namespace Athletes.News.Models.Requests;

public class DailyNewsUpdateRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public long CategoryId { get; set; }

}
