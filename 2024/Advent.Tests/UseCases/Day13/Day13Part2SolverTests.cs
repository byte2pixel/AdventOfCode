using Advent.UseCases.Day13;

namespace Advent.Tests.UseCases.Day13;

public class Day13Part2SolverTests
{
    [Fact]
    public void Solver_ShouldReturnCorrectResult()
    {
        // Arrange
        var data = Day13Parser.Parse(TestData.Day13TestData);
        // Act
        var result = new Day13Part2Solver().Solve(data);

        // Assert
        result.Should().Be(875318608908);
    }
}