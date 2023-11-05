namespace game_of_life;

public static class Parser
{
    public static IEnumerable<Cell> Parse(string[] source)
    {
        for (var y = 0; y < source.Length; y++)
        {
            var line = source[y].Replace(" ", "");
            for (var x = 0; x < line.Length; x++)
                if (line[x] == '*')
                    yield return new Cell(x, y);
        }
    }
}