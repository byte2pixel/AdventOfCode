namespace Advent.UseCases.Day3;

public static class Day3Parser
{
    public static string Parse(string input)
    {
        // remove \n and replace with ""
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        // join all lines into one string
        return string.Join("", lines);
    }
}
