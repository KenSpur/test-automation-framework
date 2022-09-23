using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QA.AcceptanceCriteria.Specs.Drivers;
using QA.Drivers.Kubernetes;
using QA.Drivers.Kubernetes.Options;
using QA.Drivers.Web;
using QA.Drivers.Web.Options;
using SolidToken.SpecFlow.DependencyInjection;

namespace QA.AcceptanceCriteria.Specs.Support;

internal static class DependencyInjectionSupport
{
    [ScenarioDependencies]
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        var config = BuildConfiguration();

        services.AddTransient<ScenarioContext>();

        services.AddTransient<ExampleDriver>();

        services.AddWebDriverAndPageObjects(
            options => config.GetSection(ChromeDriverOptions.Key).Bind(options));

        services.AddKubernetesDriver(
            options => config.GetSection(KubernetesDriverOptions.Key).Bind(options));

        return services;
    }

    private static IConfigurationRoot BuildConfiguration()
        => new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();
}