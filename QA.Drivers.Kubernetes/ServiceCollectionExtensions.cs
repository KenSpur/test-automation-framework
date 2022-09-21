using k8s;
using Microsoft.Extensions.DependencyInjection;

namespace QA.Drivers.Kubernetes;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKubernetesDriver(this IServiceCollection services, string cubeConfigPath)
    {
        services.AddTransient(provider => new Lazy<KubernetesDriver>(
            () => new KubernetesDriver(CreateKubernetesClient(cubeConfigPath))));

        return services;
    }

    private static k8s.Kubernetes CreateKubernetesClient(string cubeConfigPath)
    {
        var config = string.IsNullOrEmpty(cubeConfigPath)
            ? KubernetesClientConfiguration.BuildConfigFromConfigFile()
            : KubernetesClientConfiguration.BuildConfigFromConfigFile(cubeConfigPath);

        return new k8s.Kubernetes(config);
    }
}