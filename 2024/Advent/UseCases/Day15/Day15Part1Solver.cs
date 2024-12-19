using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day15;

internal class Day15Part1Solver : IDay15Solver
{
    GridCell _currentPosition = new(0, 0);

    public (int, string[]? grid) Solve(Day15Data data)
    {
        Stopwatch sw = new();
        sw.Start();
        _currentPosition = data.Data.Find('@'); // the @ is the starting position
        int result = RunSimulation(data);
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return (result, data.Data.ToStringArray());
    }

    private int RunSimulation(Day15Data data)
    {
        var moves = data.Moves;
        foreach (var move in moves)
        {
            // do something with the move
            Direction direction = GetDirection(move);
            var fromPostion = data.Data.FromTo(_currentPosition, direction);
            AdjustGrid(data, fromPostion);
        }
        var boxes = data.Data.FindAll('O');
        int gpsScore = 0;
        foreach (var box in boxes)
        {
            gpsScore += box.Row * 100 + box.Column;
        }
        return gpsScore;
    }

    private void AdjustGrid(Day15Data data, IEnumerable<GridCell> fromPostion)
    {
        IEnumerable<(GridCell, char)> values = data.Data[fromPostion];
        bool hasSpace = values.Any(x => x.Item2 == '.');
        if (!hasSpace)
        {
            return;
        }
        List<GridCell> cellsToMove = [];
        foreach (var (cell, value) in values)
        {
            if (value == 'O')
            {
                cellsToMove.Add(cell);
                continue;
            }
            if (value == '.')
            {
                cellsToMove.Add(cell);
                break;
            }
        }
        var grid = data.Data;
        for (int i = cellsToMove.Count - 1; i > 0; i--)
        {
            grid[cellsToMove[i]] = grid[cellsToMove[i - 1]];
        }
        grid[cellsToMove[0]] = '@';
        grid[_currentPosition] = '.';
        _currentPosition = cellsToMove[0];
    }

    private static Direction GetDirection(char move)
    {
        return move switch
        {
            '^' => Direction.North,
            'v' => Direction.South,
            '>' => Direction.East,
            '<' => Direction.West,
            _ => throw new InvalidOperationException($"Invalid move: {move}")
        };
    }
}
