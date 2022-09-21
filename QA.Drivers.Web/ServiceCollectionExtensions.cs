using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA.Drivers.Web.PageObjects;

namespace QA.Drivers.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebDriverAndPageObjects(this IServiceCollection services)
    {
        services.AddTransient(_ => new Lazy<ExamplePageObject>(
            () => new ExamplePageObject(CreateWebDriver())));

        return services;
    }

    private static IWebDriver CreateWebDriver()
    {
        var driverService = ChromeDriverService.CreateDefaultService();

        var options = new ChromeOptions();

        options.AddArgument("--headless");
        options.AddArgument("--no-sandbox");

        var chromeDriver = new ChromeDriver(driverService, options);

        return chromeDriver;
    }
}