using Advent.UseCases.Day6;
using Advent.UseCases.Day8;

namespace AdventTests.UseCases.Day8;

public class Day8Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = Day6Parser.Parse(TestData.Day8TestData);
        var solver = new Day8Part1Solver();

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(14);
    }
}
