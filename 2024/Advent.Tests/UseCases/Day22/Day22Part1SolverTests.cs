using Advent.UseCases.Day21;
using Advent.UseCases.Day22;

namespace Advent.Tests.UseCases.Day22;

public class Day22Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectValue()
    {
        // Arrange
        var input = Day21Parser.Parse(TestData.Day22TestData);
        var solver = new Day22Part1Solver(2000);

        // Act
        var solution = solver.Solve(input);

        // Assert
        solution.Should().Be("37327623");
    }
}
