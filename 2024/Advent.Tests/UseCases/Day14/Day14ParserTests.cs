using Advent.UseCases.Day14;

namespace Advent.Tests.UseCases.Day14;

public class Day14ParserTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectData()
    {
        // Act
        var result = Day14Parser.Parse(TestData.Day14TestData);

        // Assert
        result.Robots.Should().HaveCount(12);
        result.Robots[0].CurrentCell.Should().Be(new GridCell(4, 0));
        result.Robots[0].Velocity.Should().Be(new GridCell(-3, 3));
        result.Robots[11].CurrentCell.Should().Be(new GridCell(5, 9));
        result.Robots[11].Velocity.Should().Be(new GridCell(-3, -3));
    }
}
