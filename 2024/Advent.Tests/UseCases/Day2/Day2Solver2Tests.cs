using Advent.UseCases.Day2;

namespace Advent.Tests.UseCases.Day2;

public class Day2Solver2Tests
{
    [Fact]
    public void Solve_ShouldReturnCorrectResult()
    {
        // Arrange
        var solver = new Day2Part2Solver();
        List<List<int>> input =
        [
            [7, 6, 4, 2, 1],
            [1, 2, 7, 8, 9],
            [9, 7, 6, 2, 1],
            [1, 3, 2, 4, 5],
            [8, 6, 4, 4, 1],
            [1, 3, 6, 7, 9]
        ];

        // Act
        var result = solver.Solve(input);

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void Solve_ShouldReturn0_WhenInputListsAreEmpty()
    {
        // Arrange
        var solver = new Day2Part2Solver();

        // Act
        var result = solver.Solve([]);

        // Assert
        result.Should().Be(0);
    }
}
