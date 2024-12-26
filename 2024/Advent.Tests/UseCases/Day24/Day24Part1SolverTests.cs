using Advent.UseCases.Day24;

namespace Advent.Tests.UseCases.Day24;

public class Day24Part1SolverTests
{
    [Fact]
    public void Solve_WhenGivenInput_ReturnsExpected()
    {
        // Arrange
        var input = Day24Parser.Parse(TestData.Day24TestData);
        var solver = new Day24Part1Solver();

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be("4");
    }

    [Fact]
    public void Solve_WhenGivenInput_ReturnsExpected_LargerTest()
    {
        // Arrange
        var input = Day24Parser.Parse(TestData.Day24TestData2);
        var solver = new Day24Part1Solver();

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be("2024");
    }
}
