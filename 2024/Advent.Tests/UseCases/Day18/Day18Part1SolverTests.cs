using Advent.UseCases.Day18;

namespace Advent.Tests.UseCases.Day18;

public class Day18Part1SolverTests
{
    [Fact]
    public void Solve_WhenGivenExample_ReturnsExpected()
    {
        // Arrange
        var data = Day18Parser.Parse(TestData.Day18TestData);
        var solver = new Day18Part1Solver(7, 7, 12);

        // Act
        var result = solver.Solve(data);

        (string steps, string? grid) = result;
        // Assert
        steps.Should().Be("22");
        grid.Should().NotBeNullOrWhiteSpace();
        grid.AsEnumerable().Count(c => c == '#').Should().Be(12);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    public void Solve_DropsTheCorrectNumber_OfBytes_IntoGrid(int expected)
    {
        // Arrange
        var data = Day18Parser.Parse(TestData.Day18TestData);
        var solver = new Day18Part1Solver(7, 7, expected);

        // Act
        var result = solver.Solve(data);

        (_, string grid) = result;
        // Assert
        grid.Should().NotBeNullOrWhiteSpace();
        grid!.AsEnumerable().Count(c => c == '#').Should().Be(expected);
    }
}
