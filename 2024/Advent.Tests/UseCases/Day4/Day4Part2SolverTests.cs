using Advent.UseCases.Day4;

namespace Advent.Tests.UseCases.Day4;

public class Day4Part2SolverTests
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
        var solver = new Day4Part2Solver("123");

        var result = solver.Solve(data);

        result.Should().Be(4);
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
        var solver = new Day4Part2Solver("MAS");

        var result = solver.Solve(data);

        result.Should().Be(9);
    }

    [Fact]
    public void Solve_ShouldThrowArgumentException_WhenWordLengthIsEven()
    {
        Action act = static () => _ = new Day4Part2Solver("1234");

        act.Should().Throw<ArgumentException>().WithMessage("Word must have an odd length");
    }
}
