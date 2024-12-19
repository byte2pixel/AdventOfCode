using Advent.UseCases.Day15;

namespace Advent.Tests.UseCases.Day15;

public class Day15Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult()
    {
        // Arrange
        string[] expectedGrid =
        [
            "##########",
            "#.O.O.OOO#",
            "#........#",
            "#OO......#",
            "#OO@.....#",
            "#O#.....O#",
            "#O.....OO#",
            "#O.....OO#",
            "#OO....OO#",
            "##########"
        ];
        var expectedGps = 10092;

        // Act
        var data = Day15Parser.Parse(TestData.Day15TestData);
        var solver = new Day15Part1Solver();
        var result = solver.Solve(data);

        // Assert
        (int gps, string[]? gridData) = result;
        gps.Should().Be(expectedGps);
        gridData.Should().BeEquivalentTo(expectedGrid);
    }
}
