using Advent.Common;

namespace Advent.UseCases.Day18;

internal static class Day18Parser
{
    internal static List<GridCell> Parse(string input)
    {
        List<GridCell> byteCells =
        [
            .. GetCells(input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        ];
        return byteCells;
    }

    private static List<GridCell> GetCells(string[] strings)
    {
        List<GridCell> cells = [];
        foreach (var line in strings)
        {
            var coordinates = line.Split(',');
            var x = int.Parse(coordinates[0]);
            var y = int.Parse(coordinates[1]);
            cells.Add(new GridCell(y, x));
        }
        return cells;
    }
}
