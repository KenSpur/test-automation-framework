using Microsoft.Extensions.Configuration;

namespace QA.Drivers.Github.Options;

public class GithubDriverOptions
{
    public const string Key = "GITHUB_DRIVER_OPTIONS";

    [ConfigurationKeyName("PRODUCT")] 
    public string Product { get; set; } = "test-framework"; 

    [ConfigurationKeyName("PAT")]
    public string? Pat { get; set; }
}