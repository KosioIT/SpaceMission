namespace SpaceMission.Tests;

public class TestMap(string name, List<string[]> layout, List<ExpectedResult> expectations)
{
    public string Name { get; } = name;
    public List<string[]> Layout { get; } = layout;
    public List<ExpectedResult> Expectations { get; } = expectations;
}
