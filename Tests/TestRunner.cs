using SpaceMission.Services;
using SpaceMission.Views;
namespace SpaceMission.Tests;

public static class TestRunner
{
    // ----------------------------------------
    // 1) FIXED TESTS (with TestMap)
    // ----------------------------------------
    public static void RunFixedTests()
    {
        var tests = new List<TestMap>
    {
        new("Example from the task",
        [
            ["S1", "O", "X", "O", "O", "O", "S2"],
            ["X",  "O", "O", "O", "O", "X", "O"],
            ["X",  "X", "O", "X", "O", "X", "O"],
            ["O",  "X", "X", "O", "O", "X", "O"],
            ["O",  "X", "X", "O", "O", "O", "F"]
        ],
        [
            new ExpectedResult("S1", 10),
            new ExpectedResult("S2", 4)
        ])
    };

        foreach (var test in tests)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"Running test: {test.Name}");
            Console.WriteLine("=====================================");

            var grid = MapParser.Parse(test.Layout);
            var pathfinder = new Pathfinder(grid);

            MapVisualizer.ShowOriginalMap(grid);

            foreach (var astronaut in grid.Astronauts)
            {
                var path = pathfinder.FindShortestPath(astronaut.Position, grid.FinalDestination!);

                var expected = test.Expectations.First(e => e.Astronaut == astronaut.Name);

                bool pass =
                    (expected.ExpectedSteps == null && path == null) ||
                    (expected.ExpectedSteps != null && path != null && path.Count - 1 == expected.ExpectedSteps);

                Console.ForegroundColor = pass ? ConsoleColor.Green : ConsoleColor.Red;

                Console.WriteLine(pass
                    ? $"PASS: {astronaut.Name}"
                    : $"FAIL: {astronaut.Name} (expected {expected.ExpectedSteps}, got {(path == null ? "fail" : path.Count - 1)})");

                Console.ResetColor();

                if (path != null)
                    MapVisualizer.ShowPath(grid, astronaut, path);
            }

            Console.WriteLine();
        }
    }

    // ----------------------------------------
    // 2) RANDOM TESTS (no TestMap needed)
    // ----------------------------------------
    public static void RunRandomTests(int count = 10) // you can specify how many random tests to run
    {
        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"Running RANDOM test #{i}");
            Console.WriteLine("=====================================");

            var map = RandomMapGenerator.Generate(10, 10, astronauts: 3);
            var grid = MapParser.Parse(map);
            var pathfinder = new Pathfinder(grid);

            MapVisualizer.ShowOriginalMap(grid);

            foreach (var astronaut in grid.Astronauts)
            {
                var path = pathfinder.FindShortestPath(astronaut.Position, grid.FinalDestination!);

                if (path == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Astronaut {astronaut.Name}: NO PATH");
                    Console.ResetColor();
                    continue;
                }

                bool valid = PathValidator.IsValidPath(grid, path);

                Console.ForegroundColor = valid ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(valid
                    ? $"PASS: {astronaut.Name} — valid path ({path.Count - 1} steps)"
                    : $"FAIL: {astronaut.Name} — INVALID PATH");
                Console.ResetColor();

                MapVisualizer.ShowPath(grid, astronaut, path);
            }

            Console.WriteLine();
        }
    }
}
