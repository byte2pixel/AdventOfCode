using Advent.UseCases.Day19;

namespace Advent.Tests.UseCases.Day19;

public class Day19Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnNumberOfConstructedPatterns()
    {
        // Arrange
        var (buildingBlocks, targets) = Day19Parser.Parse(TestData.Day19TestData);

        // Act
        var result = new Day19Part1Solver().Solve(buildingBlocks, targets);

        // Assert
        result.Should().Be("6");
    }
}
