using SpaceMission.Models;
using SpaceMission.Services;
using SpaceMission.Views;
using SpaceMission.Tests;

class Program
{
    // Entry point of the application, can run in normal mode or test mode based on command-line arguments
    static void Main(string[] args)
    {
        bool runTests = args.Length > 0 && bool.TryParse(args[0], out var flag) && flag;

        if (runTests)
        {
            Console.WriteLine("Running tests...\n");

            TestRunner.RunFixedTests();
            TestRunner.RunRandomTests(20);

            return;
        }

        Console.WriteLine("Running normal program...\n");

        // === 1. Read input ===
        Console.Write("Map rows: ");
        int rows = int.Parse(Console.ReadLine()!);

        Console.Write("Map columns: ");
        int cols = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Cosmic map:");

        var rawMap = new List<string[]>();
        for (int i = 0; i < rows; i++)
        {
            rawMap.Add(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        Console.WriteLine(); // Blank line for better readability

        // === 2. Parse map ===
        Grid grid = MapParser.Parse(rawMap);

        // === 3. Prepare BFS ===
        var pathfinder = new Pathfinder(grid);

        // === 4. Compute paths for each astronaut ===
        var results = new List<(Astronaut astronaut, List<Point>? path)>();

        foreach (var astronaut in grid.Astronauts)
        {
            var path = pathfinder.FindShortestPath(astronaut.Position, grid.FinalDestination!);
            results.Add((astronaut, path));
        }

        // === 5. Sort: failed first, then by shortest path ===
        results = [.. results
            .OrderBy(r => r.path == null ? 0 : 1) // failures first
            .ThenBy(r => r.path?.Count ?? int.MaxValue)];

        // === 6. Print results ===
        foreach (var result in results)
        {
            var astronaut = result.astronaut;
            var path = result.path;

            if (path == null)
            {
                ConsolePrinter.PrintFailure(astronaut.Name);
                continue;
            }

            ConsolePrinter.PrintAstronautResult(astronaut.Name, path.Count - 1);

            var rendered = PathRenderer.RenderPath(grid, path);
            ConsolePrinter.PrintMap(rendered);

            Console.WriteLine();
        }
    }
}


