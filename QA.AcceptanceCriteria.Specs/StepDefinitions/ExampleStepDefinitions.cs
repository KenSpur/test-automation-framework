using k8s.Models;
using QA.AcceptanceCriteria.Specs.Drivers;
using QA.Drivers.Kubernetes;
using QA.Drivers.Web.PageObjects;

namespace QA.AcceptanceCriteria.Specs.StepDefinitions;

[Binding]
public sealed class ExampleStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly ExampleDriver _exampleDriver;
    private readonly Lazy<ExamplePageObject> _examplePageObjectLazy;
    private readonly Lazy<KubernetesDriver> _kubernetesDriverLazy;

    private static string ValidationResult => "ValidationResult";
    private static string PageTitleValue => "PageTitleValue";
    private static string Namespaces => "Namespaces";

    public ExampleStepDefinitions(ScenarioContext scenarioContext, 
        ExampleDriver exampleDriver, 
        Lazy<ExamplePageObject> examplePageObjectLazy,
        Lazy<KubernetesDriver> kubernetesDriverLazy)
    {
        _scenarioContext = scenarioContext;
        _exampleDriver = exampleDriver;
        _examplePageObjectLazy = examplePageObjectLazy;
        _kubernetesDriverLazy = kubernetesDriverLazy;
    }

    [Given("this is an example")]
    public void GivenThisIsAnExample()
    {
        _exampleDriver.SetIsExample();
    }

    [Given("we surf to '(.*)'")]
    public void GivenWeSurfTo(string url)
    { 
        _examplePageObjectLazy.Value.OpenPage(url);
    }

    [Given("we use the kubernetes driver")]
    public void GivenWeUseTHeKubernetesDriver()
    {
        _kubernetesDriverLazy.Value.Should().NotBeNull();
    }

    [When("we validate that this is an example")]
    public void WhenValidateThisIsExample()
    {
        _scenarioContext[ValidationResult] = _exampleDriver.ValidateIsExample();
    }

    [When("we view the page title")]
    public void WhenWeViewTheTitle()
    {
        _scenarioContext[PageTitleValue] = _examplePageObjectLazy.Value.GetTitleValue();
    }

    [When("we ask for all namespaces")]
    public async Task WhenWeAskForAllNamespacesAsync()
    {
        _scenarioContext[Namespaces] = await _kubernetesDriverLazy.Value.GetAllNamespacesAsync();
    }

    [Then("the validation result should confirm this is an example")]
    public void ThenValidationResultShouldBeTrue()
    {
        _scenarioContext[ValidationResult].Should().Be(true);
    }

    [Then("it should contain the word '(.*)'")]
    public void ThenShouldContain(string word)
    {
        _scenarioContext[PageTitleValue]
            .As<string>().ToLower()
            .Should().Contain(word);
    }

    [Then("we get a list of namespaces greater than '(.*)'")]
    public void ThenWeGetAListOfNamespaces(int number)
    {
        _scenarioContext[Namespaces]
            .As<IEnumerable<V1Namespace>>()
            .Count().Should().BeGreaterThan(number);
    }
}