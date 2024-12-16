using Advent.UseCases.Day12;
using Advent.UseCases.Day6;

namespace Advent.Tests.UseCases.Day12;

public class Day12Part2SolverTests
{
    [Fact]
    public void Solver_Should_Return_Expected_SimpleWalls()
    {
        // Arrange
        var data = "AAAA\n" + "BBCD\n" + "BBCC\n" + "EEEC";
        var input = Day6Parser.Parse(data);
        var solver = new Day12Part2Solver();
        // Act
        var result = solver.Solve(input);
        // Assert
        result.Should().Be(80);
    }

    [Fact]
    public void Solver_Should_Return_Expected_EWalls()
    {
        // Arrange
        var data = "EEEEE\n" + "EXXXX\n" + "EEEEE\n" + "EXXXX\n" + "EEEEE\n";
        var input = Day6Parser.Parse(data);
        var solver = new Day12Part2Solver();
        // Act
        var result = solver.Solve(input);
        // Assert
        result.Should().Be(236);
    }

    [Fact]
    public void Solver_Should_Return_Expected_ABWalls()
    {
        // Arrange
        var data = "AAAAAA\n" + "AAABBA\n" + "AAABBA\n" + "ABBAAA\n" + "ABBAAA\n" + "AAAAAA";
        var input = Day6Parser.Parse(data);
        var solver = new Day12Part2Solver();
        // Act
        var result = solver.Solve(input);
        // Assert
        result.Should().Be(368);
    }
}
