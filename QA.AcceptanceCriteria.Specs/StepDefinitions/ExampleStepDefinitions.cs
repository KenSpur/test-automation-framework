using QA.AcceptanceCriteria.Specs.Drivers;
using QA.AcceptanceCriteria.Specs.PageObjects;

namespace QA.AcceptanceCriteria.Specs.StepDefinitions;

[Binding]
public sealed class ExampleStepDefinitions : IDisposable
{
    private readonly ScenarioContext _scenarioContext;
    private readonly ExampleDriver _exampleDriver;
    private readonly BrowserDriver _browserDriver;

    private ExamplePageObject? _examplePageObject;
    
    private static string ValidationResult => "ValidationResult";
    private static string PageTitleValue => "PageTitleValue";

    public ExampleStepDefinitions(ScenarioContext scenarioContext, ExampleDriver exampleDriver, BrowserDriver browserDriver)
    {
        _scenarioContext = scenarioContext;
        _exampleDriver = exampleDriver;
        _browserDriver = browserDriver;
    }

    [Given("this is an example")]
    public void GivenThisIsAnExample()
    {
        _exampleDriver.SetIsExample();
    }

    [Given("we surf to (.*)")]
    public void GivenWeSurfTo(string url)
    {
        _examplePageObject = new ExamplePageObject(_browserDriver.Current);
        _examplePageObject.OpenPage(url);
    }

    [When("we validate that this is an example")]
    public void WhenValidateThisIsExample()
    {
        _scenarioContext[ValidationResult] = _exampleDriver.ValidateIsExample();
    }

    [When("we view the page title")]
    public void WhenWeViewTheTitle()
    {
        _scenarioContext[PageTitleValue] = _examplePageObject?.GetTitleValue();
    }

    [Then("the validation result should confirm this is an example")]
    public void ThenValidationResultShouldBeTrue()
    {
        _scenarioContext[ValidationResult].Should().Be(true);
    }

    [Then("we should see example")]
    public void ThenShouldContainExample()
    {
        _scenarioContext[PageTitleValue]
            .As<string>().ToLower()
            .Should().Contain("example");
    }

    public void Dispose()
    {
        ((IDisposable)_scenarioContext).Dispose();
        _browserDriver.Dispose();
        _examplePageObject?.Dispose();
    }
}