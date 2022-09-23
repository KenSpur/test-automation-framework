using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA.Drivers.Web.PageObjects;
using QA.Drivers.Web.Options;

namespace QA.Drivers.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebDriverAndPageObjects(this IServiceCollection services, Action<ChromeDriverOptions> configureOption)
    {
        var options = new ChromeDriverOptions();
        configureOption.Invoke(options);

        services.AddTransient(provider => new Lazy<ExamplePageObject>(
            () => new ExamplePageObject(provider.GetRequiredService<Lazy<IWebDriver>>().Value)));

        services.AddScoped(_ => new Lazy<IWebDriver>(CreateChromeDriver(options)));

        return services;
    }

    private static IWebDriver CreateChromeDriver(ChromeDriverOptions options)
    {
        var driverService = ChromeDriverService.CreateDefaultService();

        var chromeOptions = new ChromeOptions();

        foreach(var optionArgument in options.OptionArguments?.Split(' ')?? new string[0])
            chromeOptions.AddArguments(optionArgument);

        var chromeDriver = new ChromeDriver(driverService, chromeOptions);

        return chromeDriver;
    }
}