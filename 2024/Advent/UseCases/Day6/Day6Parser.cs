using Advent.Common;

namespace Advent.UseCases.Day6;

public static class Day6Parser
{
    public static GridData Parse(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var rows = lines.Length;
        var columns = lines[0].Length;

        var data = new char[rows * columns];
        for (int i = 0; i < rows; i++)
        {
            lines[i].AsSpan().CopyTo(data.AsSpan(i * columns));
        }

        return new GridData(data, rows, columns);
    }
}
