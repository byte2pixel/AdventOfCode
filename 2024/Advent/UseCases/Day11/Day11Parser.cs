namespace Advent.UseCases.Day11;

public static class Day11Parser
{
    public static ulong[] Parse(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var numbers = lines
            .SelectMany(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(ulong.Parse)
            .ToArray();
        return numbers;
    }
}
