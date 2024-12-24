namespace Advent.UseCases.Day21;

public static class Day21Parser
{
    public static string[] Parse(string input)
    {
        return input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    }
}
