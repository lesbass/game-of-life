// See https://aka.ms/new-console-template for more information

using game_of_life;

var cells = new List<Cell>();
var file = File.ReadAllLines("start.txt");
for (var y = 0; y < file.Length; y++)
{
    var line = file[y].Replace(" ", "");
    for (var x = 0; x < line.Length; x++)
        if (line[x] == '*')
            cells.Add(new Cell(x, y));
}

var universe = new Universe(cells);

while (true)
{
    Console.Clear();
    Console.WriteLine(universe.ToString());

    Thread.Sleep(1000);

    universe.Evolve();
}