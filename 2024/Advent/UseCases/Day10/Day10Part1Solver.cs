using System.Collections.Immutable;
using System.Diagnostics;
using Advent.Common;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day10;

internal struct Node
{
    public int TrailIndex { get; set; }
    public Vertex Position { get; set; }
    public Vertex Trailhead { get; set; }
}

public class Day10Part1Solver : IDay6Solver
{
    // trails start at 0 and end at 9 and must be visited in order
    private static readonly char[] trailPath = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    private readonly Dictionary<Vertex, HashSet<Vertex>> TrailheadScores = [];

    public int Solve(GridData input)
    {
        Stopwatch sw = new();
        sw.Start();
        var trailheads = input.FindAll(trailPath[0]).ToArray();
        var graph = new Queue<Node>();

        foreach (var trailhead in trailheads)
        {
            var c = input.Adjacent(trailhead);
            foreach (var vertex in c)
            {
                if (input[vertex] == trailPath[1])
                {
                    graph.Enqueue(
                        new Node
                        {
                            TrailIndex = 1,
                            Position = vertex,
                            Trailhead = trailhead
                        }
                    );
                }
            }
        }
        while (graph.Count > 0)
        {
            var node = graph.Dequeue();
            var c = input.Adjacent(node.Position, trailPath[node.TrailIndex + 1]);
            foreach (var vertex in c)
            {
                if (input[vertex] != trailPath[^1])
                {
                    graph.Enqueue(
                        new Node
                        {
                            TrailIndex = node.TrailIndex + 1,
                            Position = vertex,
                            Trailhead = node.Trailhead
                        }
                    );
                }
                else
                {
                    if (TrailheadScores.TryGetValue(node.Trailhead, out HashSet<Vertex>? score))
                    {
                        score.Add(vertex);
                    }
                    else
                    {
                        TrailheadScores[node.Trailhead] = [vertex];
                    }
                }
            }
        }
        sw.Stop(); // Averages 6 ms
        AnsiConsole.WriteLine($"FindAll took {sw.Elapsed.TotalMilliseconds} ms");
        int result = TrailheadScores.Values.Select(x => x.Count).Sum();
        return result;
    }
}
