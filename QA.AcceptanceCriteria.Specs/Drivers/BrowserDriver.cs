using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA.AcceptanceCriteria.Specs.Drivers;

/// <summary>
/// Manages a browser instance using Selenium
/// </summary>
public class BrowserDriver : IDisposable
{
    private readonly Lazy<IWebDriver> _currentWebDriverLazy;
    private bool _isDisposed;

    public BrowserDriver()
    {
        _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
    }

    /// <summary>
    /// The Selenium IWebDriver instance
    /// </summary>
    public IWebDriver Current => _currentWebDriverLazy.Value;

    /// <summary>
    /// Creates the Selenium web driver (opens a browser)
    /// </summary>
    /// <returns></returns>
    private IWebDriver CreateWebDriver()
    {
        //We use the Chrome browser
        var driverService = ChromeDriverService.CreateDefaultService();

        var options = new ChromeOptions();

        options.AddArgument("--headless");
        options.AddArgument("--no-sandbox");

        var chromeDriver = new ChromeDriver(driverService, options);

        return chromeDriver;
    }

    /// <summary>
    /// Disposes the Selenium web driver (closing the browser)
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        if (_currentWebDriverLazy.IsValueCreated)
        {
            Current.Quit();
        }

        _isDisposed = true;

        GC.SuppressFinalize(this);
    }
}