using Advent.Tests.Common;
using Advent.UseCases.Day6;

namespace Advent.Tests.UseCases.Day6;

public class Day6Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectCount()
    {
        // Arrange
        var data = Day6Parser.Parse(TestData.Day6TestData);
        var solver = new Day6Part2Solver();

        // Act
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(6);
    }
}
