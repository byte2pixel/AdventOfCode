using Advent.UseCases.Day25;

namespace Advent.Tests.UseCases.Day25;

public class Day25Part1SolverTests
{
    [Fact]
    public void Solve_WhenInputIsValid_ReturnsCorrectResult()
    {
        // Arrange
        var input = Day25Parser.Parse(TestData.Day25TestData);
        var solver = new Day25Part1Solver();

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be("3");
    }
}
