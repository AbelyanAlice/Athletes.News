namespace Athletes.News.Models.Requests;

public class DailyNewsRequest
{
    public string Title { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; } = null!;
    public long CategoryId { get; set; }

}
