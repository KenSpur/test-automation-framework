using Microsoft.Extensions.Configuration;

namespace QA.Drivers.Kubernetes.Options;

public class KubernetesDriverOptions
{
    public const string Key = "KUBERNETES_DRIVER_OPTIONS";

    [ConfigurationKeyName("CONFIG_PATH")]
    public string? ConfigPath { get; set; }
}