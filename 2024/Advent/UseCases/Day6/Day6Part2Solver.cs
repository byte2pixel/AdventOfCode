using Advent.Common;

namespace Advent.UseCases.Day6;

public class Day6Part2Solver : IDay6Solver
{
    private (int Row, int Column) _startingPosition;
    private Direction _startingDirection;
    private int _infiniteLoopCount;
    private readonly HashSet<(int Row, int Column, Direction Direction)> _turnHistory = [];

    private void Move(GridData data)
    {
        // Start at the beginning mark the valid path taken with X's
        var day6Part1 = new Day6Part1Solver();
        day6Part1.Solve(data);
        HashSet<(int Row, int Column)> _visited = [.. data.FindAll('X')];

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
        (int Row, int Column) _currentPosition,
        Direction _currentDirection
    )
    {
        while (data.IsValid(Day6Helpers.GoForwardOne(_currentPosition, _currentDirection)))
        {
            _currentPosition = Day6Helpers.GoForwardOne(_currentPosition, _currentDirection);
            if (data[_currentPosition.Row, _currentPosition.Column] == '#')
            {
                _currentPosition = Day6Helpers.GoBackOne(_currentPosition, _currentDirection);
                _currentDirection = Day6Helpers.TurnRight(_currentDirection);
                if (
                    !_turnHistory.Add(
                        (_currentPosition.Row, _currentPosition.Column, _currentDirection)
                    )
                )
                {
                    _infiniteLoopCount++;
                    break;
                }
            }
        }
    }

    public int Solve(GridData input)
    {
        _startingPosition = input.Find('^');
        _startingDirection = Direction.North;
        Move(input);
        return _infiniteLoopCount;
    }
}
