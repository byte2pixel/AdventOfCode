using Advent.UseCases.Day21;

namespace Advent.Tests.UseCases.Day21;

public class Day21Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectCost_ForDepth2()
    {
        // Arrange

        var solver = new Day21Part1Solver(2);

        // Act
        var solution = solver.Solve(["029A", "980A", "179A", "456A", "379A"]);

        // Assert
        solution.Should().Be("126384");
    }

    [Fact]
    public void Solve_ShouldReturnCorrectCost_ForDepth25()
    {
        // Arrange

        var solver = new Day21Part1Solver(25);

        // Act
        var solution = solver.Solve(["029A", "980A", "179A", "456A", "379A"]);

        // Assert
        solution.Should().Be("154115708116294");
    }
}
