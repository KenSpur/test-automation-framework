using Microsoft.Extensions.Configuration;

namespace QA.Drivers.Web.Options;

public class ChromeDriverOptions
{
    public const string Key = "CHROME_DRIVER_OPTIONS";

    [ConfigurationKeyName("OPTION_ARGUMENTS")]
    public string? OptionArguments { get; set; }
}