namespace Advent.UseCases.Day1;

public class Day1Parser
{
    private readonly List<int> _firstList = [];
    private readonly List<int> _secondList = [];

    public (List<int>, List<int>) Parse(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            if (numbers.Length == 2)
            {
                _firstList.Add(int.Parse(numbers[0]));
                _secondList.Add(int.Parse(numbers[1]));
            }
        }
        return (_firstList, _secondList);
    }
}
