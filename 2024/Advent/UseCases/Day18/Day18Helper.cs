using Advent.Common;

namespace Advent.UseCases.Day18;

internal static class Day18Helper
{
    private sealed class QueueState
    {
        public GridCell Cell { get; set; }
        public int Distance { get; set; }
    }

    internal static List<GridCell> FindPathFromTo(
        GridData grid,
        GridCell? start = null,
        GridCell? end = null
    )
    {
        GridCell nStart = start ?? new GridCell(0, 0);
        GridCell nEnd = end ?? new GridCell(grid.Rows - 1, grid.Columns - 1);

        if (nStart == nEnd)
        {
            return [nStart];
        }

        return FindShortestPath(grid, nStart, nEnd);
    }

    private static List<GridCell> FindShortestPath(GridData grid, GridCell nStart, GridCell nEnd)
    {
        var queue = new PriorityQueue<QueueState, int>();
        var visited = new HashSet<GridCell>();
        var pathMap = new Dictionary<GridCell, GridCell>();

        queue.Enqueue(new QueueState { Cell = nStart, Distance = 0 }, 0);

        while (queue.Count > 0)
        {
            var q = queue.Dequeue();
            var current = q.Cell;
            var distance = q.Distance;
            if (current == nEnd)
            {
                List<GridCell> path = [current];
                var cell = current;
                while (cell != nStart)
                {
                    cell = pathMap[cell];
                    path.Add(cell);
                }
                path.Reverse();
                return path;
            }

            foreach (var neighbor in grid.Adjacent(current))
            {
                if (grid[neighbor] == '#' || grid[neighbor] == 'S')
                {
                    continue;
                }

                if (visited.Add(neighbor))
                {
                    pathMap[neighbor] = current;
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
