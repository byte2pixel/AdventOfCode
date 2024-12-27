namespace Advent.UseCases.Day2;

internal static class Day2Parser
{
    internal static IEnumerable<IEnumerable<int>> Parse(string input)
    {
        List<List<int>> reports = [];
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            var numbers = line.Split(" ");
            if (numbers.Length > 0)
            {
                reports.Add(numbers.Select(int.Parse).ToList());
            }
        }
        return reports;
    }
}
