using Spectre.Console;

namespace Advent.UseCases.Day2;

public class Day2Part2Solver : IDay2Solver
{
    public int Solve(IEnumerable<IEnumerable<int>> input)
    {
        return input.Count(IsLineSafe);
    }

    private static bool IsLineSafe(IEnumerable<int> line)
    {
        var numbers = line.ToList();

        if (numbers.Count == 0)
            return false;

        if (numbers.Count == 1)
            return true;

        if (Day2Helpers.LineCheck(numbers))
            return true;

        return Enumerable
            .Range(0, numbers.Count)
            .Select(i => numbers.Where((_, index) => index != i))
            .Any(Day2Helpers.LineCheck);
    }
}
