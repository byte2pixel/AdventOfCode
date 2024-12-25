namespace Advent.UseCases.Day23;

public static class Day23Parser
{
    public static List<(string, string)> Parse(string input)
    {
        return input
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split("-"))
            .Select(parts => (parts[0], parts[1]))
            .ToList();
    }
}
