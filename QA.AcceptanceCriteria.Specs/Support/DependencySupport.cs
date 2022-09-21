using Microsoft.Extensions.DependencyInjection;
using QA.AcceptanceCriteria.Specs.Drivers;
using QA.Drivers.Kubernetes;
using QA.Drivers.Web;
using SolidToken.SpecFlow.DependencyInjection;

namespace QA.AcceptanceCriteria.Specs.Support;

internal static class DependencySupport
{
    [ScenarioDependencies]
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<ScenarioContext>();

        services.AddTransient<ExampleDriver>();
        services.AddWebDriverAndPageObjects();
        services.AddKubernetesDriver(Environment.GetEnvironmentVariable("KUBE_CONFIG")?? string.Empty);

        return services;
    }
}