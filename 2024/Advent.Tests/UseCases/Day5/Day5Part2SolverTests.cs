using Advent.Tests.Common;
using Advent.UseCases.Day5;

namespace Advent.Tests.UseCases.Day5;

public class Day5Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectCount()
    {
        // Arrange
        var data = Day5Parser.Parse(TestData.Day5TestData);
        var solver = new Day5Part2Solver();

        // Act
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(123);
    }
}
