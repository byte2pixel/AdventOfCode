namespace Advent.UseCases.Day6;

internal static class Day6Helpers
{
    internal static Direction TurnRight(Direction direction)
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

    internal static GridCell GoBackOne(GridCell currentPosition, Direction currentDirection)
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

    internal static GridCell GoForwardOne(GridCell currentPosition, Direction currentDirection)
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
