using SpaceMission.Models;

namespace SpaceMission.Services;

public class MapParser
{
   public static Grid Parse(List<string[]> rawMap)
    {
        int rows = rawMap.Count;
        int cols = rawMap[0].Length;

        var grid = new Grid(rows, cols);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                string cell = rawMap[r][c];
                grid.Map[r, c] = cell;

                if (cell == "F")
                    grid.FinalDestination = new Point(r, c);

                if (cell is "S1" or "S2" or "S3")
                    grid.Astronauts.Add(new Astronaut(cell, new Point(r, c)));
            }
        }

        return grid;
    }
}
