using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day6;

public class Day6Part2Solver : IDay6Solver
{
    private Vertex _startingPosition;
    private Direction _startingDirection;
    private int _infiniteLoopCount;
    private readonly HashSet<(Vertex, Direction)> _turnHistory = [];

    private void Move(GridData data)
    {
        // Start at the beginning mark the valid path taken with X's
        var day6Part1 = new Day6Part1Solver();
        day6Part1.Solve(data);
        HashSet<Vertex> _visited = [.. data.FindAll('X')];

        // no look for infinite loops by placing a # at each X
        // one at a time and checking if we can reach the end or get stuck
        foreach (var position in _visited)
        {
            var _currentDirection = _startingDirection;
            var _currentPosition = _startingPosition;
            _turnHistory.Clear();
            data[position] = '#';
            CheckForInfiniteLoop(data, _currentPosition, _currentDirection);
            data[position] = 'X';
        }
    }

    private void CheckForInfiniteLoop(
        GridData data,
        Vertex currentPosition,
        Direction currentDirection
    )
    {
        while (data.IsValid(currentPosition, currentDirection))
        {
            currentPosition = currentPosition.Go(currentDirection);
            if (data[currentPosition.Row, currentPosition.Column] == '#')
            {
                currentPosition = currentPosition.Go(currentDirection.TurnAround());
                currentDirection = currentDirection.TurnRight();
                if (!_turnHistory.Add((currentPosition, currentDirection)))
                {
                    _infiniteLoopCount++;
                    break;
                }
            }
        }
    }

    public int Solve(GridData input)
    {
        Stopwatch sw = new();
        sw.Start();
        _startingPosition = input.Find('^');
        _startingDirection = Direction.North;
        Move(input);
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return _infiniteLoopCount;
    }
}
