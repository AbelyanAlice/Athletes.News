namespace Athletes.News.Core.Configuration;

public class JwtSetting
{
    public string? Secret { get; init; }
    public TimeSpan TokenLifeTime { get; init; }
}
