using Advent.Tests.Common;
using Advent.UseCases.Day7;

namespace Advent.Tests.UseCases.Day7;

public class Day7Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectCount()
    {
        // Arrange
        var data = Day7Parser.Parse(TestData.Day7TestData);
        var solver = new Day7Part2Solver();

        // Act
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(11387);
    }
}