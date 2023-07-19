namespace Athletes.News.Domain.Entities;

public class Category
{
    public long Id { get; set; }
    public string Type { get; set; } = null!;
    public ICollection<DailyNews> DailyNews { get; set; } = new HashSet<DailyNews>();
    public ICollection<Group> Group { get; set; } = new HashSet<Group>();

}
