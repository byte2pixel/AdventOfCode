using Advent.UseCases.Day14;

namespace Advent.Tests.UseCases.Day14;

public class Day14Part2SolverTests()
{
    [Fact]
    public void Solve_ShouldReturnCorrect_Result()
    {
        // Arrange
        var data = Day14Parser.Parse(TestData.Day14TestData);
        var settings = new Day14Settings
        {
            Part = "Part 1",
            Rows = 7,
            Columns = 11,
            Seconds = 100
        };

        // Act
        (_, string[]? grid) = new Day14Part2Solver().Solve(data, settings);

        // Assert
        grid.Should().NotBeNull();
    }
}
