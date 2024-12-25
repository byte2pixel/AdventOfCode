using Advent.UseCases.Day23;

namespace Advent.Tests.UseCases.Day23;

public class Day23Part2SolverTests
{
    [Fact]
    public void Solve_WhenInputIsValid_ReturnsExpectedResult()
    {
        // Arrange
        var input = Day23Parser.Parse(TestData.Day23TestData);
        var expected = "co,de,ka,ta";
        var solver = new Day23Part2Solver();

        // Act
        var actual = solver.Solve(input);

        // Assert
        actual.Should().Be(expected);
    }
}
