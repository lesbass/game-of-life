using NUnit.Framework;

namespace game_of_life.tests;

public class UniverseTests
{
    [Test]
    public void OneCellDiesAfterOneIteration()
    {
        var universe = new Universe(new List<Cell> { new(0, 0) });

        universe.Evolve();

        Assert.IsEmpty(universe.Cells);
    }

    [Test]
    public void OneCellWith2AliveNeighborsSurvives()
    {
        var universe = new Universe(new List<Cell> { new(0, 0), new(0, 1), new(0, 2) });

        universe.Evolve();

        Assert.Contains(new Cell(0, 1), universe.Cells);
        Assert.False(universe.Cells.Contains(new Cell(0, 0)));
        Assert.False(universe.Cells.Contains(new Cell(0, 2)));
    }

    [Test]
    public void LoaderTest()
    {
        var cells = Parser.Parse(new[]
        {
            ".*.",
            ".*.",
            ".*."
        });
        var universe = new Universe(cells);

        universe.Evolve();

        var printedUniverse = universe.ToString();

        Assert.AreEqual("""
                        -------------------------------
                        
                           
                        ***
                        """, printedUniverse);
    }
}