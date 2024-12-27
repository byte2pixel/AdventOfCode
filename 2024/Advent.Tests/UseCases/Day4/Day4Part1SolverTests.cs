using Advent.UseCases.Day4;

namespace Advent.Tests.UseCases.Day4;

public class Day4Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectCount_For_XMAS()
    {
        // data that is a 10x10 crossword puzzle
        var data = new Day4Data(
            [
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            ]
        );
        var solver = new Day4Part1Solver();

        var result = solver.Solve(data);

        result.Should().Be(18);
    }
}
