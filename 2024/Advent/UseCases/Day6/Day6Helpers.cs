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

    public static Vertex GoBackOne(Vertex currentPosition, Direction currentDirection)
    {
        return currentDirection switch
        {
            Direction.North => currentPosition.South,
            Direction.East => currentPosition.West,
            Direction.South => currentPosition.North,
            Direction.West => currentPosition.East,
            _ => throw new NotImplementedException(),
        };
    }

    public static Vertex GoForwardOne(Vertex currentPosition, Direction currentDirection)
    {
        return currentDirection switch
        {
            Direction.North => currentPosition.North,
            Direction.East => currentPosition.East,
            Direction.South => currentPosition.South,
            Direction.West => currentPosition.West,
            _ => throw new NotImplementedException(),
        };
    }
}
