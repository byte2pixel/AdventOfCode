using Advent.UseCases.Day15;

namespace Advent.Tests.UseCases.Day15;

public class Day15Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult()
    {
        // Arrange
        string[] expectedGrid =
        [
            "####################",
            "##[].......[].[][]##",
            "##[]...........[].##",
            "##[]........[][][]##",
            "##[]......[]....[]##",
            "##..##......[]....##",
            "##..[]............##",
            "##..@......[].[][]##",
            "##......[][]..[]..##",
            "####################"
        ];
        var expectedGps = 9021;

        // Act
        var data = Day15Parser.ResizeGrid(Day15Parser.Parse(TestData.Day15TestData));
        var solver = new Day15Part2Solver();
        var result = solver.Solve(data);

        // Assert
        (int gps, string[]? gridData) = result;
        gps.Should().Be(expectedGps);
        gridData.Should().BeEquivalentTo(expectedGrid);
    }
}
