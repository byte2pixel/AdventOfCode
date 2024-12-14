using Advent.UseCases.Day9;

namespace Advent.Tests.UseCases.Day9;

public class Day9Part1SolverTests
{
    private readonly Day9Part1Solver _solver;

    public Day9Part1SolverTests()
    {
        _solver = new Day9Part1Solver();
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
        result.Should().Be(1928);
    }

    [Fact]
    public void Solve2_WhenInputIsValid_ReturnsHash()
    {
        var solver = new Day9Part1Solver();
        var parser = new Day9Parser();
        var parsedData = parser.Parse(TestData.Day9ParserInput);
        // Act
        ulong result = solver.Solve(parsedData);

        // Assert
        result.Should().Be(1928);
    }
}