using Advent.UseCases.Day23;

namespace Advent.Tests.UseCases.Day23;

public class Day23Part1SolverTests
{
    [Fact]
    public void Solve_WhenInputIsValid_ReturnsExpectedResult()
    {
        // Arrange
        var input = Day23Parser.Parse(TestData.Day23TestData);
        var expected = "7";
        var solver = new Day23Part1Solver();

        // Act
        var actual = solver.Solve(input);

        // Assert
        actual.Should().Be(expected);
    }
}
