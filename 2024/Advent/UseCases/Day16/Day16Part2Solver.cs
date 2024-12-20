using System.Diagnostics;
using Advent.Common;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day16;

public class Day16Part2Solver : IDay6Solver
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
        List<SearchState> validPaths = [];
        var start = input.Find('S');
        var end = input.Find('E');
        queue.Enqueue(
            new SearchState
            {
                Position = start,
                Direction = Direction.East,
                Score = 0,
                Path = [start]
            },
            0
        );
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Position == end)
            {
                validPaths.Add(current);
            }

            AdvanceThePaths(input, queue, visited, current);
        }
        var result = validPaths
            .GroupBy(x => x.Score)
            .OrderBy(g => g.Key)
            .First()
            .SelectMany(x => x.Path)
            .Distinct()
            .Count();
        return result;
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
            if (visited.TryGetValue(key, out var visitedScore) && visitedScore <= newScore - 1000)
            {
                continue;
            }
            visited[key] = newScore;
            queue.Enqueue(
                new SearchState
                {
                    Position = nextPosition,
                    Direction = newDirection,
                    Score = newScore,
                    Path = current.Path.Append(nextPosition)
                },
                newScore
            );
        }
    }
}
