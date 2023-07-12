namespace Athletes.News.Domain.Entities;

public class CustomerUser
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; } = null!;
}
