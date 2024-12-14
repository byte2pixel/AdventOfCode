using Advent.UseCases.Day9;

namespace Advent.Tests.UseCases.Day9;

public class Day9Part2SolverTests
{
    private readonly Day9Part2Solver _solver;

    public Day9Part2SolverTests()
    {
        _solver = new Day9Part2Solver();
    }

    [Fact]
    public void Solve_WhenInputIsEmpty_ReturnsZero()
    {
        // Act
        ulong result = _solver.Solve([]);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Solve_WhenInputIsValid_ReturnsHash()
    {
        // Act
        ulong result = _solver.Solve(TestData.Day9ParsedData);

        // Assert
        result.Should().Be(2858);
    }
}
