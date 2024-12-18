using Advent.Common;
using Advent.Extensions;

namespace Advent.UseCases.Day14;

public struct RobotData
{
    public GridCell CurrentCell { get; set; }
    public GridCell Velocity { get; init; }
}

public readonly ref struct Day14Data
{
    public RobotData[] Robots { get; init; }

    public GridCell[] AllRobotCells
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

    public void MoveRobots(int seconds, int maximumRows, int maximumColumns)
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
