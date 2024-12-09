namespace Advent.UseCases.Day1;

public class Day1Part2Solver : IDay1Solver
{
    public int Solve((List<int>, List<int>) input)
    {
        var (firstList, secondList) = input;
        if (firstList.Count == 0 || secondList.Count == 0)
        {
            throw new ArgumentException("Input lists cannot be empty");
        }

        int similarity = 0;

        foreach (var first in firstList)
        {
            similarity += secondList.FindAll(second => second == first).Count * first;
        }

        return similarity;
    }
}
