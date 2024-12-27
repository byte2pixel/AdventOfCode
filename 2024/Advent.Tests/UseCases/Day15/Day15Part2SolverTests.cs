using Advent.UseCases.Day15;

namespace Advent.Tests.UseCases.Day15;

public class Day15Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult_Live()
    {
        var console = new TestConsole();
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
        var solver = new Day15Part2Solver(new() { Live = true }, console);
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(expectedGps);
        console.Output.Should().ContainAll(expectedGrid);
    }

    [Fact]
    public void Solve_ShouldReturnExpectedResult()
    {
        var console = new TestConsole();
        // Arrange
        var expectedGps = 9021;

        // Act
        var data = Day15Parser.ResizeGrid(Day15Parser.Parse(TestData.Day15TestData));
        var solver = new Day15Part2Solver(new() { Live = false }, console);
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(expectedGps);
    }
}
