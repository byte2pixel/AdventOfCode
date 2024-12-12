using Advent.Common;

namespace Advent.UseCases.Day6;

public static class Day6Helpers
{
    public static Direction TurnRight(Direction direction)
    {
        return direction switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new NotImplementedException(),
        };
    }

    public static (int Row, int Column) GoBackOne(
        (int Row, int Column) currentPosition,
        Direction currentDirection
    )
    {
        return currentDirection switch
        {
            Direction.North => (currentPosition.Row + 1, currentPosition.Column),
            Direction.East => (currentPosition.Row, currentPosition.Column - 1),
            Direction.South => (currentPosition.Row - 1, currentPosition.Column),
            Direction.West => (currentPosition.Row, currentPosition.Column + 1),
            _ => throw new NotImplementedException(),
        };
    }

    public static (int Row, int Column) GoForwardOne(
        (int Row, int Column) currentPosition,
        Direction currentDirection
    )
    {
        return currentDirection switch
        {
            Direction.North => (currentPosition.Row - 1, currentPosition.Column),
            Direction.East => (currentPosition.Row, currentPosition.Column + 1),
            Direction.South => (currentPosition.Row + 1, currentPosition.Column),
            Direction.West => (currentPosition.Row, currentPosition.Column - 1),
            _ => throw new NotImplementedException(),
        };
    }
}
