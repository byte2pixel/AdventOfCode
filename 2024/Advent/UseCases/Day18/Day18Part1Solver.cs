using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day18;

internal class Day18Part1Solver(int rows, int columns, int bytesToFall = 1024) : IDay18Solver
{
    private readonly int _bytesToFall = bytesToFall;
    private readonly int _rows = rows;
    private readonly int _columns = columns;

    public (string, string) Solve(List<GridCell> data)
    {
        Stopwatch sw = new();
        sw.Start();
        int result;
        GridData grid = BuildGridData(data);
        result = Day18Helper.FindPathFromTo(grid).Count - 1; // -1 because the start cell is included
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return (result.ToString(), grid.ToString());
    }

    private GridData BuildGridData(List<GridCell> data)
    {
        var bytes = data.ToArray();
        var grid = new char[_rows * _columns];
        Array.Fill(grid, '.');
        var gridData = new GridData(grid, _rows, _columns);
        for (int i = 0; i < _bytesToFall; i++) // first X bytes to fall
        {
            gridData[bytes[i]] = '#';
        }
        return gridData;
    }
}
