using SpaceMission.Models;

namespace SpaceMission.Services;

public static class PathRenderer
{
    public static string[,] RenderPath(Grid grid, List<Point> path)
    {
        var copy = (string[,])grid.Map.Clone();

        foreach (var p in path)
        {
            if (copy[p.Row, p.Col] == "O")
                copy[p.Row, p.Col] = "*";
        }

        return copy;
    }
}
