using Advent.Common;
using Advent.Extensions;

namespace Advent.UseCases.Day14;

internal struct RobotData
{
    internal GridCell CurrentCell { get; set; }
    internal GridCell Velocity { get; init; }
}

internal readonly ref struct Day14Data
{
    internal RobotData[] Robots { get; init; }

    internal GridCell[] AllRobotCells
    {
        get
        {
            var cells = new GridCell[Robots.Length];
            for (int i = 0; i < Robots.Length; i++)
            {
                cells[i] = Robots[i].CurrentCell;
            }
            return cells;
        }
    }

    internal void MoveRobots(int seconds, int maximumRows, int maximumColumns)
    {
        for (int i = 0; i < Robots.Length; i++)
        {
            var newCell = Robots[i].CurrentCell + Robots[i].Velocity * seconds;
            Robots[i].CurrentCell = new GridCell(
                newCell.Row.Mod(maximumRows),
                newCell.Column.Mod(maximumColumns)
            );
        }
    }
}
