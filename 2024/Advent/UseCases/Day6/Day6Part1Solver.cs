using System.Diagnostics;
using Advent.Common;
using Spectre.Console;

namespace Advent.UseCases.Day6;

public class Day6Part1Solver : IDay6Solver
{
    private (int Row, int Column) _currentPosition;
    private Direction _currentDirection;

    private void MarkAsVisited(GridData data)
    {
        data[_currentPosition.Row, _currentPosition.Column] = 'X';
    }

    private void Move(GridData data)
    {
        while (data.IsValid(Day6Helpers.GoForwardOne(_currentPosition, _currentDirection)))
        {
            _currentPosition = Day6Helpers.GoForwardOne(_currentPosition, _currentDirection);
            if (data[_currentPosition.Row, _currentPosition.Column] == '#')
            {
                _currentPosition = Day6Helpers.GoBackOne(_currentPosition, _currentDirection);
                _currentDirection = Day6Helpers.TurnRight(_currentDirection);
                continue;
            }
            MarkAsVisited(data);
        }
    }

    public int Solve(GridData input)
    {
        _currentPosition = input.Find('^');
        _currentDirection = Direction.North;
        MarkAsVisited(input);
        Move(input);
        return input.Count('X');
    }
}
