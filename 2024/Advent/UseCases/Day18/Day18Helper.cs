using Advent.Common;

namespace Advent.UseCases.Day18;

internal static class Day18Helper
{
    private sealed class QueueState
    {
        public GridCell Cell { get; set; }
        public int Distance { get; set; }
    }

    /// <summary>
    /// Find the path from the top left to the bottom right of the grid
    /// avoiding the '#' characters. The path must be the shortest path
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="bytesToFall"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal static int FindPathFromTopLeftToBottomRight(GridData grid)
    {
        var start = new GridCell(0, 0);
        var end = new GridCell(grid.Rows - 1, grid.Columns - 1);
        var queue = new PriorityQueue<QueueState, int>();
        var visited = new HashSet<GridCell>();

        queue.Enqueue(new QueueState { Cell = start, Distance = 0 }, 0);

        while (queue.Count > 0)
        {
            var q = queue.Dequeue();
            var current = q.Cell;
            var distance = q.Distance;
            if (current == end)
            {
                return distance;
            }

            foreach (var neighbor in grid.Adjacent(current))
            {
                if (grid[neighbor] == '#')
                {
                    continue;
                }

                if (visited.Add(neighbor))
                {
                    queue.Enqueue(
                        new QueueState { Cell = neighbor, Distance = distance + 1 },
                        distance + 1
                    );
                }
            }
        }
        throw new InvalidOperationException("No path found");
    }
}
