using Advent.UseCases.Day11;

namespace Advent.Tests.UseCases.Day11;

public class Day11Part1SolverTests
{
    [Fact]
    public void Solver_ShouldReturnCorrectCount_25Blinks()
    {
        // Arrange
        var solver = new Day11Solver();
        var data = Day11Parser.Parse(TestData.Day11TestData);

        // Act
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(125681);
    }

    [Fact]
    public void Solver_ShouldReturnCorrectCount_1Blink()
    {
        // Arrange
        var solver = new Day11Solver(1);
        var data = Day11Parser.Parse(TestData.Day11TestData);

        // Act
        var result = solver.Solve(data);

        // Assert
        result.Should().Be(7);
    }

    [Theory]
    [InlineData(6, 22)]
    [InlineData(25, 55312)]
    public void Solver_ShouldReturnCorrectCount_6Blink(int blinks, long expected)
    {
        // Arrange
        var solver = new Day11Solver(blinks);

        // Act
        var result = solver.Solve([125, 17]);

        // Assert
        result.Should().Be(expected);
    }
}
