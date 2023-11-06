using NUnit.Framework;

namespace game_of_life.tests;

public class ParserTests
{
    [Test]
    public void ParseOnlyAliveCells()
    {
        var source = new[]
        {
            ".*.",
            ".*.",
            ".*."
        };

        var result = Parser.Parse(source).ToList();

        Assert.AreEqual(3, result.Count);

        Assert.AreEqual(new List<Cell>
        {
            new(1, 0),
            new(1, 1),
            new(1, 2)
        }, result);
    }
}