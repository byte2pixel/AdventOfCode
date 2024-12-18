using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day14;

public class Day14Part1Solver : IDay14Solver
{
    public (int, string[]?) Solve(Day14Data data, Day14Settings settings)
    {
        Stopwatch sw = new();
        sw.Start();
        int seconds = settings.Seconds,
            maximumRows = settings.Rows,
            maximumColumns = settings.Columns;
        data.MoveRobots(seconds, maximumRows, maximumColumns);
        int safteyFactor = CalculateSafetyFactor(data, maximumRows, maximumColumns);
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return (safteyFactor, null);
    }

    private static int CalculateSafetyFactor(Day14Data data, int maximumRows, int maximumColumns)
    {
        int quadrant1 = 0,
            quadrant2 = 0,
            quadrant3 = 0,
            quadrant4 = 0;
        var centerCell = new GridCell((maximumRows - 1) / 2, (maximumColumns - 1) / 2);

        data.Robots.Select(robot => robot.CurrentCell) // Step 1: Extract the cell
            .Where(cell => cell.Row != centerCell.Row && cell.Column != centerCell.Column) // Step 2: Exclude center row/col
            .ToList()
            .ForEach(cell =>
            {
                switch (GetQuadrant(cell, centerCell)) // Step 3: Count quadrants
                {
                    case 1:
                        quadrant1++;
                        break;
                    case 2:
                        quadrant2++;
                        break;
                    case 3:
                        quadrant3++;
                        break;
                    case 4:
                        quadrant4++;
                        break;
                }
            });

        return quadrant1 * quadrant2 * quadrant3 * quadrant4;
    }

    private static int GetQuadrant(GridCell cell, GridCell center)
    {
        if (cell < center)
            return 1; // Top-left
        if (cell.Row < center.Row && cell.Column > center.Column)
            return 2; // Top-right
        if (cell.Row > center.Row && cell.Column < center.Column)
            return 3; // Bottom-left
        return 4; // Bottom-right
    }
}
