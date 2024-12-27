using System.Diagnostics;
using Advent.Common;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day12;

internal struct Day12Node
{
    internal GridCell Position { get; set; }
    internal char Region { get; set; }
}

internal class Day12Part1Solver : IDay6Solver
{
    private readonly Dictionary<char, int> fenceCostPerRegion = [];
    private readonly HashSet<GridCell> visited = [];

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
                if (visited.Contains(location))
                {
                    continue;
                }
                graph.Enqueue(new Day12Node { Position = location, Region = region });
                visited.Add(location);
                int area = 1;
                int perimiter = 0;
                while (graph.Count > 0)
                {
                    var node = graph.Dequeue();
                    var c = input.Adjacent(node.Position, node.Region);
                    int unique = EnqueueNextNodes(graph, node.Region, c);
                    perimiter += 4 - c.Count();
                    area += unique;
                }
                fenceCostPerRegion[region] += area * perimiter;
            }
        }

        int result = fenceCostPerRegion.Values.Sum();
        sw.Stop(); // Average 20 ms
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private int EnqueueNextNodes(Queue<Day12Node> graph, char region, IEnumerable<GridCell> cells)
    {
        int unique = 0;
        foreach (var cell in cells)
        {
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
