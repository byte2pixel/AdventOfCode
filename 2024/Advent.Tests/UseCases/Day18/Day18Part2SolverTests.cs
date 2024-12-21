using Advent.UseCases.Day18;

namespace Advent.Tests.UseCases.Day18;

public class Day18Part2SolverTests
{
    [Fact]
    public void Solve_WhenGivenExample_ReturnsExpected()
    {
        // Arrange
        var data = Day18Parser.Parse(TestData.Day18TestData);
        var solver = new Day18Part2Solver(7, 7);

        // Act
        var result = solver.Solve(data);

        (string cell, string? grid) = result;
        // Assert
        cell.Should().Be("6,1");
        grid.Should().NotBeNullOrWhiteSpace();
    }
}
