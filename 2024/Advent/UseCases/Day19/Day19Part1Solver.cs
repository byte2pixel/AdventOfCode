using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day19;

internal class Day19Part1Solver : IDay19Solver
{
    /// <summary>
    /// Solves the problem of constructing a list target strings using
    /// a list of building blocks.
    /// </summary>
    /// <param name="buildingBlocks"></param>
    /// <param name="targets"></param>
    /// <returns></returns>
    public string Solve(List<string> buildingBlocks, List<string> targets)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        int constructed = 0;

        // ~ 8 ms on my machine or 40+ ms without Parallel.ForEach
        Parallel.ForEach(
            targets,
            target =>
            {
                if (CanConstructString(target, buildingBlocks))
                {
                    Interlocked.Increment(ref constructed);
                }
            }
        );

        stopwatch.Stop();
        AnsiConsole.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds} ms");
        return constructed.ToString();
    }

    /// <summary>
    /// Determines if a target string can be constructed from a list of building blocks.
    /// Uses dynamic programming with optimized block matching.
    /// </summary>
    private static bool CanConstructString(string target, IList<string> buildingBlocks)
    {
        int n = target.Length;
        bool[] dpTable = new bool[n + 1];
        dpTable[0] = true;

        // Pre-process building blocks by length for faster lookup
        var blocksByLength = new Dictionary<int, List<string>>();
        foreach (var block in buildingBlocks)
        {
            if (!blocksByLength.ContainsKey(block.Length))
                blocksByLength[block.Length] = [];
            blocksByLength[block.Length].Add(block);
        }

        // For each position in the target string
        for (int i = 0; i < n; i++)
        {
            // If we can't build up to this position, skip it
            if (!dpTable[i])
                continue;

            // Only check blocks that could possibly fit
            foreach (var kvp in blocksByLength)
            {
                int blockLen = kvp.Key;
                // Skip if this block would extend beyond target length
                if (i + blockLen > n)
                    continue;

                // Get the substring we're trying to match
                string targetSubstring = target.Substring(i, blockLen);

                // Check if any block of this length matches
                if (kvp.Value.Contains(targetSubstring))
                {
                    dpTable[i + blockLen] = true;
                }
            }
        }

        return dpTable[n];
    }
}
