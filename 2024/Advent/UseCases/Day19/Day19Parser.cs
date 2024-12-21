namespace Advent.UseCases.Day19;

public static class Day19Parser
{
    public static (List<string> buildingBlocks, List<string> targets) Parse(string input)
    {
        var parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var buildingBlocks = parts[0]
            .Split("\n")[0]
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        var targets = parts[1].Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();

        return (buildingBlocks, targets);
    }
}