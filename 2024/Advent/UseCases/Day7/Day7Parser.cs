namespace Advent.UseCases.Day7;

internal static class Day7Parser
{
    internal static (ulong, uint[])[] Parse(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        (ulong, uint[])[] result = new (ulong, uint[])[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(": ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                var children = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                result[i] = (ulong.Parse(parts[0]), children.Select(uint.Parse).ToArray());
            }
            else
            {
                throw new InvalidOperationException("Invalid input");
            }
        }
        return result;
    }
}
