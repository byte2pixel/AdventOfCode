using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day6;

public class Day6Part1Solver : IDay6Solver
{
    private GridCell _currentPosition;
    private Direction _currentDirection;

    private void MarkAsVisited(GridData data)
    {
        data[_currentPosition.Row, _currentPosition.Column] = 'X';
    }

    private void Move(GridData data)
    {
        while (data.IsValid(_currentPosition, _currentDirection))
        {
            _currentPosition = _currentPosition.Go(_currentDirection);
            if (data[_currentPosition] == '#')
            {
                _currentPosition = _currentPosition.Go(_currentDirection.TurnAround());
                _currentDirection = _currentDirection.TurnRight();
                continue;
            }
            MarkAsVisited(data);
        }
    }

    public int Solve(GridData input)
    {
        Stopwatch sw = new();
        sw.Start();
        _currentPosition = input.Find('^');
        _currentDirection = Direction.North;
        MarkAsVisited(input);
        Move(input);
        var count = input.Count('X');
        sw.Stop(); // Average 2.75 ms
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return count;
    }
}
