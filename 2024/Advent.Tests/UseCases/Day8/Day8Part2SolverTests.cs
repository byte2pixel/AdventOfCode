using Advent.UseCases.Day6;
using Advent.UseCases.Day8;

namespace Advent.Tests.UseCases.Day8;

public class Day8Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = Day6Parser.Parse(TestData.Day8TestData);
        var solver = new Day8Part2Solver();

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(34);
    }
}
