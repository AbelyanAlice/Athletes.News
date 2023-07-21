namespace Athletes.News.Models.Requests;

public class GroupRequest
{
    public string Name { get; set; } = null!;
    public long CategoryId { get; set; }
}
