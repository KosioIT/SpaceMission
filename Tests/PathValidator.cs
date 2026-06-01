using SpaceMission.Models;

namespace SpaceMission.Tests;

public static class PathValidator
{
    public static bool IsValidPath(Grid grid, List<Point> path)
    {
        // 1. Path must start at astronaut
        var start = path.First();
        if (!grid.Astronauts.Any(a => a.Position.Row == start.Row && a.Position.Col == start.Col))
            return false;

        // 2. Path must end at F
        var end = path.Last();
        if (grid.FinalDestination!.Row != end.Row || grid.FinalDestination.Col != end.Col)
            return false;

        // 3. No walls
        foreach (var p in path)
        {
            if (grid.Map[p.Row, p.Col] == "X")
                return false;
        }

        // 4. Steps must be adjacent
        for (int i = 1; i < path.Count; i++)
        {
            int dr = Math.Abs(path[i].Row - path[i - 1].Row);
            int dc = Math.Abs(path[i].Col - path[i - 1].Col);
            if (dr + dc != 1)
                return false;
        }

        return true;
    }
}
