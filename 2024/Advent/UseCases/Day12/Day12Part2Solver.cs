using System.Diagnostics;
using Advent.Common;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day12;

internal class Day12Part2Solver() : IDay6Solver
{
    private readonly Dictionary<char, int> fenceCostPerRegion = [];
    private readonly HashSet<GridCell> visited = [];

    // North and South need to use columns
    // East and West need to use rows
    // to caclulate the continuous fence lengths
    private readonly HashSet<(GridCell, Direction)> wallHistory = [];

    public int Solve(GridData input)
    {
        var regions = input.GetUniqueChars();
        Stopwatch sw = new();
        sw.Start();

        foreach (var region in regions)
        {
            fenceCostPerRegion[region] = 0;
            var regionLocations = input.FindAll(region);
            var graph = new Queue<Day12Node>();
            foreach (var location in regionLocations)
            {
                wallHistory.Clear();
                if (visited.Contains(location))
                {
                    continue;
                }
                graph.Enqueue(new Day12Node { Position = location, Region = region });
                visited.Add(location);
                int area = 1;
                while (graph.Count > 0)
                {
                    var node = graph.Dequeue();
                    var c = GridData.AdjacentUnsafe(node.Position);
                    int unique = EnqueueNextNodes(node, graph, input, node.Region, c);
                    area += unique;
                }
                int walls = GetContinousWallLengths();
                fenceCostPerRegion[region] += area * walls;
            }
        }

        int result = fenceCostPerRegion.Values.Sum();
        sw.Stop(); // Average 33 ms super messy solution :)
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private int GetContinousWallLengths()
    {
        // filter for all north walls
        int wallCount = 0;
        Dictionary<int, List<int>> wallAccumulator = [];
        var walls = wallHistory.Where(w => w.Item2 == Direction.North);
        NorthSouthWalls(wallAccumulator, walls);
        wallCount += wallAccumulator.Values.Select(c => CountGaps(c)).Sum();
        wallAccumulator.Clear();

        walls = wallHistory.Where(w => w.Item2 == Direction.South);
        NorthSouthWalls(wallAccumulator, walls);
        wallCount += wallAccumulator.Values.Select(c => CountGaps(c)).Sum();
        wallAccumulator.Clear();

        walls = wallHistory.Where(w => w.Item2 == Direction.East);
        EasWestWalls(wallAccumulator, walls);
        wallCount += wallAccumulator.Values.Select(c => CountGaps(c)).Sum();
        wallAccumulator.Clear();

        walls = wallHistory.Where(w => w.Item2 == Direction.West);
        EasWestWalls(wallAccumulator, walls);
        wallCount += wallAccumulator.Values.Select(c => CountGaps(c)).Sum();

        return wallCount;
    }

    private static void NorthSouthWalls(
        Dictionary<int, List<int>> wallAccumulator,
        IEnumerable<(GridCell, Direction)> walls
    )
    {
        walls
            .Select(wall => wall.Item1)
            .ToList()
            .ForEach(wall =>
            {
                if (wallAccumulator.TryGetValue(wall.Row, out List<int>? columns))
                {
                    columns.Add(wall.Column);
                }
                else
                {
                    wallAccumulator[wall.Row] = [wall.Column];
                }
            });
    }

    private static void EasWestWalls(
        Dictionary<int, List<int>> wallAccumulator,
        IEnumerable<(GridCell, Direction)> walls
    )
    {
        walls
            .Select(wall => wall.Item1)
            .ToList()
            .ForEach(wall =>
            {
                if (wallAccumulator.TryGetValue(wall.Column, out List<int>? rows))
                {
                    rows.Add(wall.Row);
                }
                else
                {
                    wallAccumulator[wall.Column] = [wall.Row];
                }
            });
    }

    private static int CountGaps(List<int> columns)
    {
        columns.Sort();
        int gaps = 0;
        for (int i = 0; i < columns.Count - 1; i++)
        {
            if (columns[i] + 1 != columns[i + 1])
            {
                gaps++;
            }
        }
        if (gaps == 0)
        {
            return 1;
        }
        else
        {
            return gaps + 1;
        }
    }

    private int EnqueueNextNodes(
        Day12Node currentNode,
        Queue<Day12Node> graph,
        GridData input,
        char region,
        IEnumerable<GridCell> cells
    )
    {
        int unique = 0;
        foreach (var cell in cells)
        {
            bool isValid = input.IsValid(cell);
            if (!isValid || input[cell] != region)
            {
                Direction wallDirection = Direction.North;
                if (cell.Row == currentNode.Position.Row + 1)
                {
                    wallDirection = Direction.South;
                }
                else if (cell.Row == currentNode.Position.Row - 1)
                {
                    wallDirection = Direction.North;
                }
                else if (cell.Column == currentNode.Position.Column + 1)
                {
                    wallDirection = Direction.East;
                }
                else if (cell.Column == currentNode.Position.Column - 1)
                {
                    wallDirection = Direction.West;
                }
                wallHistory.Add((cell, wallDirection));
                continue;
            }
            if (visited.Contains(cell))
            {
                continue;
            }
            unique++;
            // could track visited nodes here to avoid revisiting
            // if coming from the same trailhead, but it slows down the process
            // because the data set is small
            graph.Enqueue(new Day12Node { Position = cell, Region = region });
            visited.Add(cell);
        }
        return unique;
    }
}
