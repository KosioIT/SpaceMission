namespace SpaceMission.Models;

public class Astronaut(string name, Point position)
{
    public string Name { get; } = name;
    public Point Position { get; } = position;
}
