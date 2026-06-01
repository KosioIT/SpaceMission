using SpaceMission.Models;

namespace SpaceMission.Services;

public class Pathfinder(Grid grid)
{
    private readonly Grid _grid = grid;

    public List<Point>? FindShortestPath(Point start, Point end)
    {
        var queue = new Queue<Point>();
        var visited = new bool[_grid.Rows, _grid.Cols];
        var parent = new Point?[_grid.Rows, _grid.Cols];

        queue.Enqueue(start);
        visited[start.Row, start.Col] = true;

        int[] dr = [-1, 1, 0, 0];
        int[] dc = [0, 0, -1, 1];

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Row == end.Row && current.Col == end.Col)
                return ReconstructPath(parent, start, end);

            for (int i = 0; i < 4; i++)
            {
                int nr = current.Row + dr[i];
                int nc = current.Col + dc[i];

                if (IsValid(nr, nc) && !visited[nr, nc] && _grid.Map[nr, nc] != "X")
                {
                    visited[nr, nc] = true;
                    parent[nr, nc] = current;
                    queue.Enqueue(new Point(nr, nc));
                }
            }
        }

        return null;
    }

    private bool IsValid(int r, int c)
        => r >= 0 && r < _grid.Rows && c >= 0 && c < _grid.Cols;

    private static List<Point> ReconstructPath(Point?[,] parent, Point start, Point end)
    {
        var path = new List<Point>();
        var current = end;

        while (!(current.Row == start.Row && current.Col == start.Col))
        {
            path.Add(current);
            current = parent[current.Row, current.Col]!;
        }

        path.Add(start);
        path.Reverse();
        return path;
    }
}
