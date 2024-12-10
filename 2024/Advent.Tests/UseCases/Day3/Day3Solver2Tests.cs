using Advent.UseCases.Day3;

namespace Advent.Tests.UseCases.Day3;

public class Day3Solver2Tests
{
    private const string TestData =
        "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    [Fact]
    public void Solve_ShouldReturnCorrectResult()
    {
        // Arrange
        var solver = new Day3Part2Solver();

        // Act
        var result = solver.Solve(TestData);

        // Assert
        result.Should().Be(48);
    }
}
