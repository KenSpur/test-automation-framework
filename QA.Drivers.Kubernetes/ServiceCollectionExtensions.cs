using k8s;
using Microsoft.Extensions.DependencyInjection;
using QA.Drivers.Kubernetes.Options;

namespace QA.Drivers.Kubernetes;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKubernetesDriver(this IServiceCollection services, Action<KubernetesDriverOptions> configureOptions)
    {
        var options = new KubernetesDriverOptions();
        configureOptions.Invoke(options);

        services.AddScoped(_ => new Lazy<KubernetesDriver>(
            () => new KubernetesDriver(CreateKubernetesClient(options.ConfigPath))));

        return services;
    }

    private static k8s.Kubernetes CreateKubernetesClient(string? configPath)
    {
        var config = string.IsNullOrEmpty(configPath)
            ? KubernetesClientConfiguration.BuildConfigFromConfigFile()
            : KubernetesClientConfiguration.BuildConfigFromConfigFile(configPath);

        return new k8s.Kubernetes(config);
    }
}