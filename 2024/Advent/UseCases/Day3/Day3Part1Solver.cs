using System.Text.RegularExpressions;

namespace Advent.UseCases.Day3;

internal partial class Day3Part1Solver : IDay3Solver
{
    [GeneratedRegex(@"mul\((?<num1>\d{1,3}),(?<num2>\d{1,3})\)")]
    private static partial Regex MultiplicationPattern();

    public int Solve(string input)
    {
        var matches = MultiplicationPattern().Matches(input);
        return matches.Sum(match =>
        {
            int num1 = int.Parse(match.Groups["num1"].Value);
            int num2 = int.Parse(match.Groups["num2"].Value);
            return num1 * num2;
        });
    }
}
