using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day15;

internal class Day15Part2Solver : IDay15Solver
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
            if (direction == Direction.East || direction == Direction.West)
            {
                var fromPostion = data.Data.FromTo(_currentPosition, direction);
                SimpleAdjustGrid(data, fromPostion);
            }
            else
            {
                var fromPostion = data.Data.FromTo(_currentPosition, direction);
                ComplexAdjustGrid(data, fromPostion, direction);
            }
        }
        var boxes = data.Data.FindAll('[');
        int gpsScore = 0;
        foreach (var box in boxes)
        {
            gpsScore += box.Row * 100 + box.Column;
        }
        return gpsScore;
    }

    private void ComplexAdjustGrid(
        Day15Data data,
        IEnumerable<GridCell> fromPostion,
        Direction direction
    )
    {
        IEnumerable<(GridCell, char)> values = data.Data[fromPostion];
        bool hasSpace = values.Any(x => x.Item2 == '.');
        if (!hasSpace)
        {
            return;
        }
        List<GridCell> searchWidth = GetAllCellsToMove(data, direction);
        var columnsToMove = data.Data[searchWidth].Select(x => x.Item1).GroupBy(c => c.Column);
        var grid = data.Data;
        foreach (var column in columnsToMove)
        {
            var sorted =
                Direction.North == direction
                    ? column.OrderByDescending(c => c.Row).ToList()
                    : [.. column.OrderBy(c => c.Row)];
            for (int i = sorted.Count - 1; i > 0; i--)
            {
                grid[sorted[i]] = data.Data[sorted[i - 1]];
            }
            if (column.Key == _currentPosition.Column)
            {
                grid[sorted[0]] = '@';
                grid[_currentPosition] = '.';
                _currentPosition = sorted[0];
            }
            else
            {
                grid[sorted[0]] = '.';
            }
        }
    }

    private List<GridCell> GetAllCellsToMove(Day15Data data, Direction direction)
    {
        Queue<GridCell> searchQueue = new();
        HashSet<GridCell> visited = [];
        searchQueue.Enqueue(_currentPosition.Go(direction));
        visited.Add(_currentPosition.Go(direction));
        List<GridCell> searchWidth = [];
        while (searchQueue.Count > 0)
        {
            var cell = searchQueue.Dequeue();
            if (!data.Data.IsValid(cell))
                continue;

            if (data.Data[cell] == '#')
            {
                searchWidth.Clear(); // wall, clear all searchWidth
                break; // stop searching
            }
            if (data.Data[cell] == '.')
            {
                searchWidth.Add(cell); // space to move
                continue;
            }
            // either [ or ] representing a double wide box
            HandleDoubleWideBoxes(data, direction, searchQueue, visited, searchWidth, cell);
        }

        return searchWidth;
    }

    private static void HandleDoubleWideBoxes(
        Day15Data data,
        Direction direction,
        Queue<GridCell> searchQueue,
        HashSet<GridCell> visited,
        List<GridCell> searchWidth,
        GridCell cell
    )
    {
        Direction neighborDirection = data.Data[cell] == '[' ? Direction.East : Direction.West;
        searchWidth.Add(cell);
        var neighbor = cell.Go(neighborDirection);
        if (visited.Add(neighbor))
        {
            searchQueue.Enqueue(neighbor);
        }
        var nextCell = cell.Go(direction);
        visited.Add(nextCell);
        searchQueue.Enqueue(nextCell);
    }

    private void SimpleAdjustGrid(Day15Data data, IEnumerable<GridCell> fromPostion)
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
            if (value == '[' || value == ']')
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
