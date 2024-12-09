namespace Advent.UseCases.Day1;

public class Day1Part1Solver : IDay1Solver
{
    public int Solve((List<int>, List<int>) input)
    {
        var (firstList, secondList) = input;
        if (firstList.Count == 0 || secondList.Count == 0)
        {
            throw new ArgumentException("Input lists cannot be empty");
        }

        if (firstList.Count != secondList.Count)
        {
            throw new ArgumentException("Input lists must have the same length");
        }

        firstList.Sort();
        secondList.Sort();

        int difference = 0;
        for (var i = 0; i < firstList.Count; i++)
        {
            difference += Math.Abs(firstList[i] - secondList[i]);
        }

        return difference;
    }
}
