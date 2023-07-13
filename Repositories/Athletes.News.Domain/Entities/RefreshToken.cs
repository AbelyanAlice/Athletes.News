using Athletes.News.Domain.Entities;
using System.Data;

namespace Athletes.News.Infrastructure.Configuration.Users;

public class RefreshToken
{
    public long Id { get; set; }
    public string? Value { get; set; }
    public string? JwtId { get; set; }
    public DataSetDateTime CreationDate { get; set; }
    public DataSetDateTime ExpiryData { get; set; }
    public bool Used { get; set; }
    public bool Invalidated { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
}
