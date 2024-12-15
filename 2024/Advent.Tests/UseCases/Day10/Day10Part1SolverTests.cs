using Advent.UseCases.Day10;
using Advent.UseCases.Day6;

namespace Advent.Tests.UseCases.Day10;

public class Day10Part1SolverTests
{
    [Fact]
    public void Day10Part1Solver_ShouldReturnExpectedResult()
    {
        // Arrange
        var solver = new Day10Part1Solver();
        var input = Day6Parser.Parse(TestData.Day10TestData);

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(36);
    }

    [Fact]
    public void Day10Part1Solver_ShouldReturnExpectedResult2()
    {
        // Arrange
        var solver = new Day10Part1Solver();
        var input = Day6Parser.Parse(TestData.Day10TestData2);

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void Day10Part1Solver_ShouldReturnExpectedResult3()
    {
        // Arrange
        var solver = new Day10Part1Solver();
        var input = Day6Parser.Parse(TestData.Day10TestData3);

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(4);
    }
}
