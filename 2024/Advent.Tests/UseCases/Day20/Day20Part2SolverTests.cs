using Advent.UseCases.Day20;
using Advent.UseCases.Day6;

namespace Advent.Tests.UseCases.Day20;

public class Day20Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnShortestPathLength_Part1Test()
    {
        // Arrange
        var input = Day6Parser.Parse(TestData.Day20TestData);

        // Act
        var result = new Day20Solver(0, 2).Solve(input);

        // Assert
        result.Should().Be(44);
    }

    [Fact]
    public void Solve_ShouldReturnShortestPathLength_Part2Test()
    {
        // Arrange
        var input = Day6Parser.Parse(TestData.Day20TestData);

        // Act
        var result = new Day20Solver(50, 20).Solve(input);

        // Assert
        result.Should().Be(285);
    }
}
