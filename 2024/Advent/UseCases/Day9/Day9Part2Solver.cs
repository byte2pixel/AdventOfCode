using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day9;

internal class Day9Part2Solver : IDay9Solver
{
    /// <summary>
    /// This is a bit slower than the first part, but still performs well ~700ms
    /// but I'm going to punt optimizing this further for now, to try to catch up on the calendar
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public ulong Solve(Span<uint> input)
    {
        Stopwatch sw = new();
        sw.Start();

        // Step 2: Copy the span up to and including the first uint.MaxValue
        var (fileId, index, count) = FindFileToMove(input);
        var freeSpace = FindFreeSpaceChunk(input, count, index - 1);
        while (index > 0)
        {
            // splice the file id into the free space in the input span
            if (freeSpace.index >= 0)
            {
                for (int i = 0; i < count; i++)
                {
                    input[freeSpace.index + i] = fileId;
                    input[index + i] = uint.MaxValue;
                }
            }
            (fileId, index, count) = FindFileToMove(input, index - 1);
            freeSpace = FindFreeSpaceChunk(input, count, index - 1);
        }

        ulong hash = ComputeHash(input);
        sw.Stop(); // averages 760 ms
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return hash;
    }

    /// <summary>
    /// Finds the last consecutive run of file ids in the span
    /// skips over free space (uint.MaxValue)
    /// </summary>
    /// <param name="span"></param>
    /// <param name="lastIndex"></param>
    /// <returns></returns>
    private static (uint fileId, int index, int count) FindFileToMove(
        Span<uint> span,
        int? lastIndex = null
    )
    {
        if (span.IsEmpty)
            return (uint.MaxValue, -1, 0); // No data in the span

        int startIndex = lastIndex.HasValue
            ? Math.Min(lastIndex.Value, span.Length - 1)
            : span.Length - 1;
        uint lastValue = span[startIndex];
        while (lastValue == uint.MaxValue)
        {
            if (startIndex == 0)
            {
                return (uint.MaxValue, -1, 0); // No data in the span
            }
            lastValue = span[--startIndex];
        }
        int count = 1;

        for (int i = startIndex - 1; i >= 0; i--)
        {
            if (span[i] == lastValue)
            {
                count++;
            }
            else
            {
                // We found the end of the consecutive run
                return (lastValue, i + 1, count); // (start index, count)
            }
        }

        // If we reach here, the entire span is a consecutive run
        return (lastValue, 0, count);
    }

    /// <summary>
    /// Looks or free space chunks that can fit the space needed for the file
    /// </summary>
    /// <param name="span"></param>
    /// <param name="spaceNeeded"></param>
    /// <param name="endIndex"></param>
    /// <returns></returns>
    private static (uint fileId, int index, int count) FindFreeSpaceChunk(
        Span<uint> span,
        int spaceNeeded,
        int? endIndex = null
    )
    {
        if (span.IsEmpty || spaceNeeded <= 0)
            return (uint.MaxValue, -1, 0); // No data or invalid space needed

        int stopIndex = endIndex.HasValue
            ? Math.Min(endIndex.Value, span.Length - 1)
            : span.Length - 1;

        int consecutiveCount = 0;
        int startIndex = -1;

        for (int i = 0; i <= stopIndex; i++)
        {
            if (span[i] == uint.MaxValue)
            {
                if (consecutiveCount == 0)
                {
                    startIndex = i; // Start of a new run
                }

                consecutiveCount++;

                if (consecutiveCount >= spaceNeeded)
                {
                    // We found a suitable consecutive run
                    return (uint.MaxValue, startIndex, consecutiveCount);
                }
            }
            else
            {
                // Reset the run
                consecutiveCount = 0;
                startIndex = -1;
            }
        }

        // No suitable run found
        return (uint.MaxValue, -1, 0);
    }

    private static ulong ComputeHash(Span<uint> input)
    {
        ulong hash = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == uint.MaxValue)
            {
                continue;
            }
            hash += input[i] * (ulong)i;
        }

        return hash;
    }
}
