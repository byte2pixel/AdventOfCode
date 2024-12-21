using Advent.UseCases.Day19;

namespace Advent.Tests.UseCases.Day19;

public class Day19Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturn_NumberOfPossibilities()
    {
        // Arrange
        var (buildingBlocks, targets) = Day19Parser.Parse(TestData.Day19TestData);

        // Act
        var result = new Day19Part2Solver().Solve(buildingBlocks, targets);

        // Assert
        result.Should().Be("16");
    }
}
