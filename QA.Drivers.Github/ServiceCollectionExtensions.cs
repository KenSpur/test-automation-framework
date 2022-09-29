using Microsoft.Extensions.DependencyInjection;
using Octokit;
using QA.Drivers.Github.Options;

namespace QA.Drivers.Github;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGithubDriver(this IServiceCollection services, Action<GithubDriverOptions> configureOptions)
    {
        var options = new GithubDriverOptions();
        configureOptions.Invoke(options);

        services.AddScoped(_ => new Lazy<GithubDriver>(
            () => new GithubDriver(CreateGithubClient(options))));

        return services;
    }

    private static GitHubClient CreateGithubClient(GithubDriverOptions options)
        => new(new ProductHeaderValue(options.Product))
        {
            Credentials = new Credentials(options.Pat)
        };
}