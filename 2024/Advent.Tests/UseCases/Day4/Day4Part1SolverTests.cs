using Advent.UseCases.Day4;

namespace Advent.Tests.UseCases.Day4;

public class Day4Part1SolverTests
{
    [Fact]
    public void Solve_ShouldReturnCorrectCount()
    {
        // data that is a 10x10 crossword puzzle
        var data = new Day4Data(
            [
                "1234167890",
                "1234267890",
                "1234367890",
                "1233367890",
                "3321267890",
                "1234167893",
                "3234567831",
                "1334567220",
                "1224561390",
                "1231563890"
            ]
        );
        var solver = new Day4Part1Solver("1233");

        var result = solver.Solve(data);

        result.Should().Be(8);
    }

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
        var solver = new Day4Part1Solver("XMAS");

        var result = solver.Solve(data);

        result.Should().Be(18);
    }
}
