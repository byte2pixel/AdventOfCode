using Advent.UseCases.Day16;
using Advent.UseCases.Day6;

namespace Advent.Tests.UseCases.Day16;

public class Day16Part2SolverTests
{
    [Fact]
    public void Solve_ShouldReturnExpectedResult()
    {
        var input = Day6Parser.Parse(TestData.Day16TestData);
        var solver = new Day16Part2Solver();

        var result = solver.Solve(input);

        result.Should().Be(45);
    }

    [Fact]
    public void Solve_ShouldReturnExpectedResult2()
    {
        var input = Day6Parser.Parse(TestData.Day16TestData2);
        var solver = new Day16Part2Solver();

        var result = solver.Solve(input);

        result.Should().Be(64);
    }
}
