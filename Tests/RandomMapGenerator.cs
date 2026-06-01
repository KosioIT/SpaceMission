namespace SpaceMission.Tests;

public static class RandomMapGenerator
{
    private static readonly Random Rng = new();

    public static List<string[]> Generate(int rows, int cols, int astronauts = 1)
    {
        var map = new List<string[]>();

        for (int r = 0; r < rows; r++)
        {
            var row = new string[cols];
            for (int c = 0; c < cols; c++)
            {
                row[c] = Rng.NextDouble() < 0.25 ? "X" : "O"; // 25% walls, 75% open space
            }
            map.Add(row);
        }

        // Place final destination
        int fr = Rng.Next(rows);
        int fc = Rng.Next(cols);
        map[fr][fc] = "F";

        // Place astronauts
        for (int i = 1; i <= astronauts; i++)
        {
            int ar, ac;
            do
            {
                ar = Rng.Next(rows);
                ac = Rng.Next(cols);
            }
            while (map[ar][ac] != "O");

            map[ar][ac] = $"S{i}";
        }

        return map;
    }
}
