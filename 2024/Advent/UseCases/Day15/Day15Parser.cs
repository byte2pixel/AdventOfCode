using Advent.Common;

namespace Advent.UseCases.Day15;

internal readonly ref struct Day15Data
{
    public GridData Data { get; init; }
    public char[] Moves { get; init; }
}

internal static class Day15Parser
{
    internal static Day15Data Parse(string input)
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

    internal static Day15Data ResizeGrid(Day15Data data)
    {
        int rows = data.Data.Rows;
        int columns = data.Data.Columns * 2;
        var grid = new char[rows * columns];
        for (int i = 0; i < rows; i++)
        {
            var row = data.Data[i];
            for (int j = 0; j < columns / 2; j++)
            {
                int expandedIndex = i * columns + j * 2;
                int nextIndex = expandedIndex + 1;
                switch (row[j])
                {
                    case 'O':
                        grid[expandedIndex] = '[';
                        grid[nextIndex] = ']';
                        break;
                    case '@':
                        grid[expandedIndex] = '@';
                        grid[nextIndex] = '.';
                        break;
                    default:
                        grid[expandedIndex] = row[j];
                        grid[nextIndex] = row[j];
                        break;
                }
            }
        }
        var newData = new Day15Data
        {
            Data = new GridData(grid, rows, columns),
            Moves = data.Moves
        };
        return newData;
    }
}
