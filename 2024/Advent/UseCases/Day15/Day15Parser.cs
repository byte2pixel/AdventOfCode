using Advent.Common;

namespace Advent.UseCases.Day15;

internal readonly ref struct Day15Data
{
    public GridData Data { get; init; }
    public char[] Moves { get; init; }
}

internal static class Day15Parser
{
    public static Day15Data Parse(string input)
    {
        var gridAndMoves = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var gridLines = gridAndMoves[0].Split("\n", StringSplitOptions.RemoveEmptyEntries);
        int rows = gridLines.Length;
        int columns = gridLines[0].Length;
        var grid = new char[rows * columns];
        for (int i = 0; i < rows; i++)
        {
            gridLines[i].AsSpan().CopyTo(grid.AsSpan(i * columns));
        }
        var moves = gridAndMoves[1].Where(c => c != '\n').ToArray();

        return new Day15Data { Data = new GridData(grid, rows, columns), Moves = moves };
    }
}
