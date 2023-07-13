using System.Data;

namespace Athletes.News.Domain.Entities;

public class RefreshToken
{
    public long Id { get; set; }
    public string? Value { get; set; }
    public string? JwtId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpiryData { get; set; }
    public bool Used { get; set; }
    public bool Invalidated { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
}
