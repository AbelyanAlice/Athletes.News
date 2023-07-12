using Athletes.News.Core.Infrastructures.DependencyInjection.Assembly;
using Athletes.News.Core.Infrastructures.DependencyInjection.LifeTime;
using Microsoft.Extensions.DependencyInjection;

namespace Athletes.News.Core.Infrastructures.DependencyInjection;

public static class DependencyInjection
{
    public static void RegisterAllDependencies(this IServiceCollection services)
    {
        var (scopedServices, transientServices, singletonServices) = GetInjectableServicesServices("Athletes411");
        foreach (var item in scopedServices)
        {
            var serviceType = AssemblyDetails.GetNamedInterface(item);
            var descriptor = new ServiceDescriptor(serviceType, item, ServiceLifetime.Scoped);
            if (!services.Contains(descriptor))
            {
                services.Add(descriptor);
            }
        }
        foreach (var item in transientServices)
        {
            var serviceType = AssemblyDetails.GetNamedInterface(item);
            var descriptor = new ServiceDescriptor(serviceType, item, ServiceLifetime.Transient);
            if (!services.Contains(descriptor))
            {
                services.Add(descriptor);
            }
        }
        foreach (var item in singletonServices)
        {
            var serviceType = AssemblyDetails.GetNamedInterface(item);
            var descriptor = new ServiceDescriptor(serviceType, item, ServiceLifetime.Singleton);
            if (!services.Contains(descriptor))
            {
                services.Add(descriptor);
            }
        }
    }
    /// <summary>
    /// Returns all services that implemented one of interfaces as injection lifetime.
    /// </summary>
    /// <param name="assemblyName">Prefix from assembly name.</param>
    /// <returns></returns>
    private static (IEnumerable<Type> scopedServices, IEnumerable<Type> transientServices, IEnumerable<Type>
        singltonServices) GetInjectableServicesServices(string assemblyName)
    {
        var allTypes = AssemblyDetails.FromAssembliesInSearchPath(assemblyName)
            .Where(type => typeof(ISingleton).IsAssignableFrom(type)
                           || typeof(IScoped).IsAssignableFrom(type)
                           || typeof(ITransient).IsAssignableFrom(type)
                           && !type.IsInterface
                           && !type.IsAbstract);
        var enumerable = allTypes.ToList();
        var scopedServices = enumerable.Where(type => typeof(IScoped).IsAssignableFrom(type));
        var transientServices = enumerable.Where(type => typeof(ITransient).IsAssignableFrom(type));
        var singletonServices = enumerable.Where(type => typeof(ISingleton).IsAssignableFrom(type));
        return (scopedServices, transientServices, singletonServices);
    }
}
