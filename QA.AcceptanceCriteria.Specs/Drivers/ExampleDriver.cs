namespace QA.AcceptanceCriteria.Specs.Drivers;

public class ExampleDriver
{
    private bool _isExample;

    public void SetIsExample()
    {
        _isExample = true;
    }

    public bool ValidateIsExample()
        => _isExample;
}