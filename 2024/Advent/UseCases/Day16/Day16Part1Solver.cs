using System.Diagnostics;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day16;

internal class Day16Part1Solver : IDay6Solver
{
    public int Solve(GridData input)
    {
        Stopwatch sw = new();
        sw.Start();
        int result = SearchTheMaze(input);
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private static int SearchTheMaze(GridData input)
    {
        var queue = new PriorityQueue<SearchState, int>();
        var visited = new Dictionary<(GridCell, Direction), int>();
        var start = input.Find('S');
        var end = input.Find('E');
        queue.Enqueue(
            new SearchState
            {
                Position = start,
                Direction = Direction.East,
                Score = 0
            },
            0
        );
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Position == end)
            {
                return current.Score;
            }

            AdvanceThePaths(input, queue, visited, current);
        }
        throw new InvalidOperationException("No path through the maze was found.");
    }

    private static void AdvanceThePaths(
        GridData input,
        PriorityQueue<SearchState, int> queue,
        Dictionary<(GridCell, Direction), int> visited,
        SearchState current
    )
    {
        foreach (var newDirection in Enum.GetValues<Direction>())
        {
            var nextPosition = current.Position.Go(newDirection);
            if (
                current.Direction.TurnAround() == newDirection
                || !input.IsValid(nextPosition)
                || input[nextPosition] == '#'
            )
            {
                continue;
            }

            int turnCost = current.Direction != newDirection ? 1000 : 0;
            int newScore = current.Score + turnCost + 1;

            var key = (nextPosition, newDirection);
            if (visited.TryGetValue(key, out var visitedScore) && visitedScore <= newScore)
            {
                continue;
            }
            visited[key] = newScore;
            queue.Enqueue(
                new SearchState
                {
                    Position = nextPosition,
                    Direction = newDirection,
                    Score = newScore
                },
                newScore
            );
        }
    }
}
