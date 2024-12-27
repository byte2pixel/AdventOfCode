using Advent.UseCases.Day15;

namespace Advent.Tests.UseCases.Day15;

public class Day15Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult_Live()
    {
        var console = new TestConsole();
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
        var solver = new Day15Part1Solver(new() { Live = true }, console);
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
        var expectedGps = 10092;

        // Act
        var data = Day15Parser.Parse(TestData.Day15TestData);
        var solver = new Day15Part1Solver(new() { Live = false }, console);
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(expectedGps);
    }
}
