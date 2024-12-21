using Advent.UseCases.Day18;

namespace Advent.Tests.UseCases.Day18;

public class Day18ParserTests
{
    [Fact]
    public void Parse_ShouldReturnGridCells_WhenInputIsValid()
    {
        // Arrange
        var input = "1,1\n1,2\n2,1\n2,2\n";
        var expected = new List<GridCell> { new(1, 1), new(1, 2), new(2, 1), new(2, 2) };

        // Act
        var result = Day18Parser.Parse(input);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Parse_ShouldReturnGridCells_WhenInputIsValid2()
    {
        // Act
        var result = Day18Parser.Parse(TestData.Day18TestData);

        // Assert
        result.Should().HaveCount(25);
    }
}
