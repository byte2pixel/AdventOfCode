using System.Diagnostics;
using Advent.Common;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day10;

internal struct Day10Node
{
    public int TrailIndex { get; set; }
    public GridCell Position { get; set; }
    public GridCell Trailhead { get; set; }
}

internal class Day10Part1Solver : IDay6Solver
{
    // trails start at 0 and end at 9 and must be visited in order
    private static readonly char[] trailPath = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    private readonly Dictionary<GridCell, HashSet<GridCell>> TrailheadScores = [];

    /// <summary>
    /// Find all trailheads and then traverse the graph to find all possible paths
    /// only counting the unique trail ends
    /// </summary>
    public int Solve(GridData input)
    {
        Stopwatch sw = new();
        sw.Start();
        var trailheads = input.FindAll(trailPath[0]).ToArray();
        var graph = new Queue<Day10Node>();

        foreach (var trailhead in trailheads)
        {
            var c = input.Adjacent(trailhead, trailPath[1]);
            EnqueueNextNode(input, graph, trailhead, c);
        }

        while (graph.Count > 0)
        {
            var node = graph.Dequeue();
            var c = input.Adjacent(node.Position, trailPath[node.TrailIndex + 1]);
            EnqueueNextNode(input, graph, node.Trailhead, c, node.TrailIndex + 1);
        }
        int result = TrailheadScores.Values.Select(x => x.Count).Sum();
        sw.Stop(); // Averages 6 ms
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private void EnqueueNextNode(
        GridData input,
        Queue<Day10Node> graph,
        GridCell trailhead,
        IEnumerable<GridCell> c,
        int nextNodeIndex = 1
    )
    {
        foreach (var cell in c)
        {
            if (input[cell] != trailPath[^1])
            {
                // could track visited nodes here to avoid revisiting
                // if coming from the same trailhead, but it slows down the process
                // because the data set is small
                graph.Enqueue(
                    new Day10Node
                    {
                        TrailIndex = nextNodeIndex,
                        Position = cell,
                        Trailhead = trailhead
                    }
                );
            }
            else
            {
                if (TrailheadScores.TryGetValue(trailhead, out HashSet<GridCell>? score))
                {
                    score.Add(cell);
                }
                else
                {
                    TrailheadScores[trailhead] = [cell];
                }
            }
        }
    }
}
