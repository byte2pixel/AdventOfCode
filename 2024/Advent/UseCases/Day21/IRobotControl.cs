using Advent.Common;

namespace Advent.UseCases.Day21;

public interface IRobotControl
{
    public char Move(Direction direction);
    public char CurrentKey { get; }
    public List<Direction> AvailableMoves(GridCell newPosition);
}
