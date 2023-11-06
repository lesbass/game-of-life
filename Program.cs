using game_of_life;

var file = File.ReadAllLines("start.txt");
var cells = Parser.Parse(file);
var universe = new Universe(cells);

while (true)
{
    Console.Clear();
    Console.WriteLine(universe.ToString());

    Thread.Sleep(1000);

    universe.Evolve();
}