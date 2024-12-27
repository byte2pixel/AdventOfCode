namespace Advent.UseCases.Day21;

internal static class Day21Parser
{
    internal static string[] Parse(string input)
    {
        return input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    }
}
