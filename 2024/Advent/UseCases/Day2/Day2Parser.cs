namespace Advent.UseCases.Day2;

public class Day2Parser
{
    private readonly List<List<int>> reports = [];

    public IEnumerable<IEnumerable<int>> Parse(string input)
    {
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
