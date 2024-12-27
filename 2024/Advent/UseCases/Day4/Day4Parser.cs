namespace Advent.UseCases.Day4;

internal readonly ref struct Day4Data(string[] input)
{
    public readonly char[] FlatCrossword { get; } = input.SelectMany(x => x).ToArray();
    public readonly int Rows { get; } = input.Length;
    public readonly int Columns { get; } = input[0].Length;
}

internal static class Day4Parser
{
    public static Day4Data Parse(string input)
    {
        // remove all \n from the string input
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        bool allSameLength = lines.All(x => x.Length == lines[0].Length);
        if (!allSameLength)
        {
            throw new ArgumentException("All parsed lines must have the same length");
        }
        return new Day4Data(lines);
    }
}
