using Advent.UseCases.Day1;

namespace Advent.Tests.UseCases.Day1;

public class Day1ParserTests
{
    [Fact]
    public void Parse_ShouldReturnTwoListsOfInts()
    {
        // Arrange
        var parser = new Day1Parser();
        var input = "17211   12345\n" + "12397   34356\n" + "36633   45832\n" + "29933   67531\n";

        // Act
        var result = parser.Parse(input);

        // Assert
        result.Item1.Should().BeEquivalentTo([17211, 12397, 36633, 29933]);
        result.Item2.Should().BeEquivalentTo([12345, 34356, 45832, 67531]);
    }
}
