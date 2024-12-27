using Advent.UseCases.Day22;

namespace Advent.Tests.UseCases.Day22;

public class Day22Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectValue()
    {
        // Arrange
        string[] input = ["1", "2", "3", "2024"];
        var solver = new Day22Part2Solver(2000);

        // Act
        var solution = solver.Solve(input);

        // Assert
        solution.Should().Be("23");
    }
}
