using System.Text.RegularExpressions;

namespace Advent.UseCases.Day3;

internal partial class Day3Part2Solver : IDay3Solver
{
    [GeneratedRegex(@"do\(\)|don't\(\)|mul\((?<num1>\d{1,3}),(?<num2>\d{1,3})\)")]
    private static partial Regex MultiplicationPattern2();

    private bool _isDo = true;

    public int Solve(string input)
    {
        var matches = MultiplicationPattern2().Matches(input);
        return matches.Sum(match =>
        {
            if (match.Value == "do()")
            {
                _isDo = true;
                return 0;
            }
            if (match.Value == "don't()")
            {
                _isDo = false;
                return 0;
            }
            if (!_isDo)
            {
                return 0;
            }
            int num1 = int.Parse(match.Groups["num1"].Value);
            int num2 = int.Parse(match.Groups["num2"].Value);
            return num1 * num2;
        });
    }
}
