namespace Athletes.News.Api.Installer;

public interface IInstaller
{
    void InstallerService(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment emv);
}
