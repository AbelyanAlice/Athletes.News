using System.Reflection;

namespace Athletes.News.Api.Installer;

public static class InstallerExtesions
{
    public static void InstallServicesInAssembly(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment env)
    {
        var installers = Assembly.GetExecutingAssembly()
            .ExportedTypes
            .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();
        installers.ForEach(installer => installer.InstallerService(services, configuration, env));
    }
}
