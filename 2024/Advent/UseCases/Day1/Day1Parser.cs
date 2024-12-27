namespace Advent.UseCases.Day1;

internal static class Day1Parser
{
    internal static (List<int>, List<int>) Parse(string input)
    {
        List<int> _firstList = [];
        List<int> _secondList = [];

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
