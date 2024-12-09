namespace Advent.UseCases.Day2;

public class Day2Part1Solver : IDay2Solver
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

        return Day2Helpers.LineCheck(numbers);
    }
}
