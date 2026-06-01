namespace SpaceMission.Tests;

public class ExpectedResult(string astronaut, int? expectedSteps)
{
    public string Astronaut { get; } = astronaut;
    public int? ExpectedSteps { get; } = expectedSteps; // null means no path (failure)
}
