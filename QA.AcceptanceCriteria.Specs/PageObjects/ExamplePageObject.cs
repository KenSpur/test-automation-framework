using OpenQA.Selenium;

namespace QA.AcceptanceCriteria.Specs.PageObjects;

public class ExamplePageObject : IDisposable
{
    private readonly IWebDriver _webDriver;
    private IWebElement H1Element => _webDriver.FindElement(By.CssSelector("h1"));

    public ExamplePageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void OpenPage(string url)
    {
        if (_webDriver.Url == url) return;

        _webDriver.Navigate().GoToUrl(url);
    }

    public string GetTitleValue()
        => H1Element.Text;

    public void Dispose()
    {
        _webDriver.Dispose();
    }
}