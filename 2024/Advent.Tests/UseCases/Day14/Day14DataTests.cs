using Advent.UseCases.Day14;

namespace Advent.Tests.UseCases.Day14;

public class Day14DataTests
{
    private static Day14Data Data =>
        new()
        {
            Robots =
            [
                new RobotData { CurrentCell = new GridCell(4, 2), Velocity = new GridCell(-3, 2) },
            ]
        };

    [Theory]
    [InlineData(1, 1, 4)]
    [InlineData(2, 5, 6)]
    [InlineData(3, 2, 8)]
    [InlineData(4, 6, 10)]
    [InlineData(5, 3, 1)]
    public void MoveRobots_ShouldMoveRobots(int moves, int expectedRow, int expectedColumn)
    {
        // Arrange
        var data = Data;

        // Act
        data.MoveRobots(moves, 7, 11);

        // Assert
        data.Robots[0].CurrentCell.Should().Be(new GridCell(expectedRow, expectedColumn));
    }

    [Fact]
    public void MoveRobots_ShouldMoveCorrectly_After100Seconds()
    {
        // Arrange
        var data = Day14Parser.Parse(TestData.Day14TestData);

        // Act
        data.MoveRobots(100, 7, 11);

        // Assert
        // ......2..1.
        // ...........
        // 1..........
        // .11........
        // .....1.....
        // ...12......
        // .1....1....
        data.Robots[6].CurrentCell.Should().Be(new GridCell(0, 6));
        data.Robots[9].CurrentCell.Should().Be(new GridCell(0, 6));
        data.Robots[2].CurrentCell.Should().Be(new GridCell(0, 9));

        data.Robots[8].CurrentCell.Should().Be(new GridCell(2, 0));

        data.Robots[5].CurrentCell.Should().Be(new GridCell(3, 1));
        data.Robots[7].CurrentCell.Should().Be(new GridCell(3, 2));

        data.Robots[1].CurrentCell.Should().Be(new GridCell(4, 5));

        data.Robots[0].CurrentCell.Should().Be(new GridCell(5, 3));
        data.Robots[3].CurrentCell.Should().Be(new GridCell(5, 4));
        data.Robots[10].CurrentCell.Should().Be(new GridCell(5, 4));

        data.Robots[4].CurrentCell.Should().Be(new GridCell(6, 1));
        data.Robots[11].CurrentCell.Should().Be(new GridCell(6, 6));
    }
}
