using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day18;

public class Day18Part2Solver(int rows, int columns) : IDay18Solver
{
    private readonly int _rows = rows;
    private readonly int _columns = columns;

    public (string, string) Solve(List<GridCell> data)
    {
        Stopwatch sw = new();
        sw.Start();

        #region linear search approach
#pragma warning disable S125
        // linear search approach, much slower > 3 seconds
        // binary search is 10ms
        /*
        var grid = BuildGridData();
        foreach (var cell in data)
        {
            grid[cell] = '#';
            try
            {
                Day18Helper.FindPathFromTopLeftToBottomRight(grid);
            }
            catch (InvalidOperationException)
            {
                sw.Stop();
                AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
                return ($"{cell.Column},{cell.Row}", grid.ToString());
            }
        }
        */
#pragma warning restore S125
        #endregion

        // binary search approach < 10 ms
        int left = 0;
        int right = data.Count - 1;
        GridData grid = BuildGridData();
        GridCell firstFail = data[^1];
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            var testCell = data[mid];
            for (int i = 0; i <= mid; i++)
            {
                grid[data[i]] = '#';
            }
            try
            {
                Day18Helper.FindPathFromTo(grid);
                left = mid + 1;
            }
            catch (InvalidOperationException)
            {
                right = mid - 1;
                firstFail = testCell;
            }
            grid = BuildGridData(); // reset the grid
        }
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return ($"{firstFail.Column},{firstFail.Row}", grid.ToString());
    }

    private GridData BuildGridData()
    {
        var grid = new char[_rows * _columns];
        Array.Fill(grid, '.');
        return new GridData(grid, _rows, _columns);
    }
}
