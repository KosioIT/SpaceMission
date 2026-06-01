using SpaceMission.Models;
using SpaceMission.Services;
using SpaceMission.Views;

namespace SpaceMission.Tests;

public static class MapVisualizer
{
    public static void ShowOriginalMap(Grid grid)
    {
        Console.WriteLine("Original map:");
        ConsolePrinter.PrintMap(grid.Map);
        Console.WriteLine();
    }

    public static void ShowPath(Grid grid, Astronaut astronaut, List<Point> path)
    {
        Console.WriteLine($"Path for {astronaut.Name}:");

        var rendered = PathRenderer.RenderPath(grid, path);
        ConsolePrinter.PrintMap(rendered);

        Console.WriteLine();
    }
}
