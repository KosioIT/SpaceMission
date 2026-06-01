namespace SpaceMission.Models;

public class Grid(int rows, int cols)
{
    public int Rows { get; } = rows;
    public int Cols { get; } = cols;
    public string[,] Map { get; } = new string[rows, cols];

    public Point? FinalDestination { get; set; }
    public List<Astronaut> Astronauts { get; } = [];
}
