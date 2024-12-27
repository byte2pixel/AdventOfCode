using System.Collections.Concurrent;
using System.Diagnostics;
using Advent.Common;
using Advent.UseCases.Day18;
using Advent.UseCases.Day6;
using Spectre.Console;

namespace Advent.UseCases.Day20;

internal class Day20Solver(int savingsThreshold, int cheatDistance) : IDay6Solver
{
    private readonly int _savingsThreshold = savingsThreshold;
    private readonly HashSet<(GridCell, GridCell)> possibleCheats = [];

    // there is still something slow about this. ~800ms in release mode
    // but seems to be the best I can do for now, to move on to day 21
    public int Solve(GridData input)
    {
        Stopwatch sw = new();
        sw.Start();
        ConcurrentDictionary<int, int> cheatCounter = [];
        GridCell start = input.Find('S');
        GridCell end = input.Find('E');
        // Find the regular path from start to end
        List<GridCell> originalPath = Day18Helper.FindPathFromTo(input, start, end);
        // Create a dictionary of the original path with the index of each cell
        Dictionary<GridCell, int> originalWithIndex = originalPath
            .Select((cell, index) => (cell, index))
            .ToDictionary(x => x.cell, x => x.index);

        // Find all possible cheats for each cell in the original path
        foreach (var cell in originalPath)
        {
            IEnumerable<GridCell> tempCheats = input
                .FindAll(cell, cheatDistance, ['.', 'S', 'E'])
                .Where(x => originalWithIndex[x] > originalWithIndex[cell]);
            foreach (var cheat in tempCheats)
            {
                possibleCheats.Add((cell, cheat));
            }
        }
        ProcessPossibleCheats(possibleCheats, cheatCounter, originalWithIndex);
        int result = cheatCounter.Where(x => x.Key >= _savingsThreshold).Sum(x => x.Value);
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private static void ProcessPossibleCheats(
        HashSet<(GridCell, GridCell)> possibleCheats,
        ConcurrentDictionary<int, int> cheatCounter,
        Dictionary<GridCell, int> originalPathWithIndex
    )
    {
        OrderablePartitioner<(GridCell, GridCell)> partitioner = Partitioner.Create(possibleCheats);

        Parallel.ForEach(
            partitioner,
            () => new Dictionary<int, int>(),
            (possibleCheat, loopState, localDict) =>
            {
                GridCell fromCell = possibleCheat.Item1;
                GridCell cheat = possibleCheat.Item2;
                int currentDistance = originalPathWithIndex[fromCell];
                int newDistance = originalPathWithIndex[cheat];

                if (currentDistance <= newDistance)
                {
                    int shortcut = cheat.ManhattanDistance(fromCell);
                    var timeSavings = newDistance - currentDistance - shortcut;

                    if (timeSavings > 0)
                    {
                        localDict.TryGetValue(timeSavings, out int count);
                        localDict[timeSavings] = count + 1;
                    }
                }
                return localDict;
            },
            (localDict) =>
            {
                foreach (var kvp in localDict)
                {
                    cheatCounter.AddOrUpdate(
                        kvp.Key,
                        kvp.Value,
                        (key, oldValue) => oldValue + kvp.Value
                    );
                }
            }
        );
    }
}
