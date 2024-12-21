using System.Diagnostics;
using Advent.Extensions;
using Spectre.Console;

namespace Advent.UseCases.Day14;

public class Day14Part2Solver : IDay14Solver
{
    public (int, string[]?) Solve(Day14Data data, Day14Settings settings)
    {
        Stopwatch sw = new();
        sw.Start();
        int seconds = 1,
            maximumRows = settings.Rows,
            maximumColumns = settings.Columns;
        int iterationCount = 0;
        while (iterationCount < 10000)
        {
            iterationCount++;
            data.MoveRobots(seconds, maximumRows, maximumColumns);
            var consecutiveCols = data.AllRobotCells.FindConsecutiveCellsInColumn(6);
            if (consecutiveCols is not null && consecutiveCols.Count() >= 4)
            {
                break;
            }
        }
        string[]? grid = CreateGrid(data, maximumRows, maximumColumns);
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return (iterationCount * seconds, grid);
    }

    private static string[]? CreateGrid(Day14Data data, int maximumRows, int maximumColumns)
    {
        string[] grid = new string[maximumRows];
        for (int i = 0; i < maximumRows; i++)
        {
            grid[i] = new string('.', maximumColumns);
        }

        foreach (var robotCell in data.Robots.Select(robot => robot.CurrentCell))
        {
            grid[robotCell.Row] = grid[robotCell.Row]
                .Remove(robotCell.Column, 1)
                .Insert(robotCell.Column, "#");
        }

        return grid;
    }
}
