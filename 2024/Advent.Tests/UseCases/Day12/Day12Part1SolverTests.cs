using Advent.UseCases.Day12;
using Advent.UseCases.Day6;

namespace Advent.Tests.UseCases.Day12;

public class Day12Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult()
    {
        // Given
        var input = Day6Parser.Parse(TestData.Day12TestData);

        var solver = new Day12Part1Solver();

        // When
        var result = solver.Solve(input);

        // Then
        result.Should().Be(1930);
    }
}
