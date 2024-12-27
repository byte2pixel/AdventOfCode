using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day15;

internal class Day15Part1Solver(Day15Settings settings, IAnsiConsole console) : IDay15Solver
{
    GridCell _currentPosition = new(0, 0);
    Table? _liveTable = null;

    public int Solve(Day15Data data)
    {
        Stopwatch sw = new();
        sw.Start();
        int result = 0;
        _currentPosition = data.Data.Find('@'); // the @ is the starting position
        if (!settings.Live)
        {
            result = RunSimulation(data);
            sw.Stop();
            console.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
            return result;
        }

        _liveTable = new Table();
        _liveTable.AddColumn(new TableColumn("Day 15 Part 1").Centered());
        for (int i = 0; i < data.Data.Rows; i++)
        {
            _liveTable.AddRow(new Text(data.Data[i].ToString()).Centered());
        }
        result = console
            .Live(_liveTable)
            .AutoClear(false)
            .Overflow(VerticalOverflow.Visible)
            .Start(ctx =>
            {
                void Update(int delay, Action action)
                {
                    action();
                    ctx.Refresh();
                    Thread.Sleep(delay);
                }
                ctx.Refresh();
                int result = RunSimulation(data, Update);
                ctx.Refresh();
                return result;
            });
        return result;
    }

    private int RunSimulation(Day15Data data, Action<int, Action>? update = null)
    {
        var moves = data.Moves;
        for (int i = 0; i < moves.Length; i++)
        {
            // do something with the move
            Direction direction = GetDirection(moves[i]);
            var fromPostion = data.Data.FromTo(_currentPosition, direction);
            AdjustGrid(data, fromPostion);
            if (update is not null && i % 15 == 0)
            {
                UpdateLiveTableRows(data, update);
            }
        }
        UpdateLiveTableRows(data, update);
        var boxes = data.Data.FindAll('O');
        int gpsScore = 0;
        foreach (var box in boxes)
        {
            gpsScore += box.Row * 100 + box.Column;
        }
        return gpsScore;
    }

    private void UpdateLiveTableRows(Day15Data data, Action<int, Action>? update)
    {
        update?.Invoke(
            1,
            () =>
            {
                for (int i = 0; i < data.Data.Rows; i++)
                {
                    _liveTable?.Rows.Update(i, 0, new Text(data.Data[i].ToString()).Centered());
                }
            }
        );
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
