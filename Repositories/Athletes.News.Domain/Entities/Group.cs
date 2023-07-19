namespace Athletes.News.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<Team> Team { get; set; } = new HashSet<Team>();

}
