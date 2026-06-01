using SpaceMission.Models;

namespace SpaceMission.Views;

public static class ConsolePrinter
{
    public static void PrintMap(string[,] map)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write(map[r, c] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintAstronautResult(string name, int steps)
    {
        Console.WriteLine($"Astronaut {name} - Shortest path: {steps} steps");
    }

    public static void PrintFailure(string name)
    {
        Console.WriteLine($"Mission failed — Astronaut {name} lost in space!");
    }
}
