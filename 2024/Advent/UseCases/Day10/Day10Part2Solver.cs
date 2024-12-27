using System.Diagnostics;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day10;

internal class Day10Part2Solver : IDay6Solver
{
    // trails start at 0 and end at 9 and must be visited in order
    private static readonly char[] trailPath = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    private readonly Dictionary<GridCell, int> TrailheadScores = [];

    /// <summary>
    /// Basically the same as Part 1, but we're counting the number of times we reach the end of the trail
    /// including branches that join back up
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
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
        int result = TrailheadScores.Values.Sum();
        sw.Stop(); // Averages 5.4 ms
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private void EnqueueNextNode(
        GridData input,
        Queue<Day10Node> graph,
        GridCell trailhead,
        IEnumerable<GridCell> cells,
        int nextNodeIndex = 1
    )
    {
        foreach (var cell in cells)
        {
            if (input[cell] != trailPath[^1])
            {
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
                if (TrailheadScores.TryGetValue(trailhead, out int score))
                {
                    TrailheadScores[trailhead] = score + 1;
                }
                else
                {
                    TrailheadScores[trailhead] = 1;
                }
            }
        }
    }
}
