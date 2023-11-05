using System.Text;

namespace game_of_life;

public class Universe
{
    public Universe(List<Cell> cells)
    {
        Cells = cells;
    }

    private List<Cell> Cells { get; set; }

    public void Evolve()
    {
        var cellsWithDeadNeighbors = new List<Cell>(Cells);
        foreach (var cell in Cells)
        {
            var neighbors = GetNeighbors(cell, cellsWithDeadNeighbors);
            foreach (var neighbor in neighbors)
                if (!cellsWithDeadNeighbors.Contains(neighbor))
                    cellsWithDeadNeighbors.Add(neighbor);
        }

        var newCells = new List<Cell>();
        foreach (var cell in cellsWithDeadNeighbors)
        {
            var isAlive = false;
            var aliveNeighbors = CountAliveNeighbors(cell, cellsWithDeadNeighbors);
            if (aliveNeighbors == 3) isAlive = true;
            else if (cell.IsAlive && aliveNeighbors == 2) isAlive = true;

            var newCell = cell with { IsAlive = isAlive };

            newCells.Add(newCell);
        }

        Cells = newCells.Where(c => c.IsAlive).ToList();
    }

    private static int CountAliveNeighbors(Cell cell, List<Cell> cells)
    {
        var neighbors = GetNeighbors(cell, cells);

        return neighbors.Count(n => n.IsAlive);
    }

    private static IEnumerable<Cell> GetNeighbors(Cell cell, List<Cell> cells)
    {
        for (var x = -1; x <= 1; x++)
        for (var y = -1; y <= 1; y++)
        {
            if (x == 0 && y == 0) continue;
            yield return cells.FirstOrDefault(c => c.X == cell.X + x && c.Y == cell.Y + y) ??
                         new Cell(cell.X + x, cell.Y + y, false);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("-------------------------------");
        if (Cells.Any())
            for (var y = Math.Min(0, Cells.Min(c => c.Y)); y <= Cells.Max(c => c.Y); y++)
            {
                sb.AppendLine();
                for (var x = Math.Min(0, Cells.Min(c => c.X)); x <= Cells.Max(c => c.X); x++)
                    sb.Append(Cells.Any(c => c.X == x && c.Y == y && c.IsAlive) ? "*" : " ");
            }

        return sb.ToString();
    }
}