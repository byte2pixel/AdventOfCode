using System.Buffers;
using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day9;

internal class Day9Part1Solver : IDay9Solver
{
    public ulong Solve(Span<uint> input)
    {
        Stopwatch sw = new();
        sw.Start();

        // Step 1: Find the index of the first uint.MaxValue
        int index = input.IndexOf(uint.MaxValue);
        if (index != -1)
        {
            // Step 2: Copy the span up to and including the first uint.MaxValue
            Span<uint> subSpan = input[index..];

            // Rent an array from the pool to reduce allocations
            var reversedArrayRental = ArrayPool<uint>.Shared.Rent(subSpan.Length);
            Span<uint> reversedArray = reversedArrayRental.AsSpan(0, subSpan.Length);

            // Step 3: Create a copy and reverse it
            subSpan.CopyTo(reversedArray);
            reversedArray.Reverse();

            // Step 3: get all non-max values and count the max values
            int fileCount = 0;
            int freeSpaceCount = 0;

            var fileIds = new uint[reversedArray.Length];

            // Combine filtering and counting in a single pass
            GetFileIdsAndFreeSpace(reversedArray, ref fileCount, ref freeSpaceCount, fileIds);

            // Trim the non-max values array
            fileIds = fileIds.AsSpan(0, fileCount).ToArray();

            // Step 4: Replace the max values with the non-max values
            CompactFreeSpace(input, fileIds);

            // Step 5: Copy the max values to the end of the array
            AppendFreeSpaceToEnd(input, freeSpaceCount);
        }
        // Step 6: Compute the hash
        ulong hash = ComputeHash(input);
        sw.Stop(); // averages 3.7 ms
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");
        return hash;
    }

    private static void AppendFreeSpaceToEnd(Span<uint> input, int freeSpaceCount)
    {
        uint[] maxValueEntries = new uint[freeSpaceCount];
        Array.Fill(maxValueEntries, uint.MaxValue);
        maxValueEntries.CopyTo(input[^freeSpaceCount..]);
    }

    private static void CompactFreeSpace(Span<uint> input, uint[] fileIds)
    {
        int nextNonMaxIndex = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == uint.MaxValue)
            {
                input[i] = fileIds[nextNonMaxIndex];
                nextNonMaxIndex++;
            }
        }
    }

    private static void GetFileIdsAndFreeSpace(
        Span<uint> reversedArray,
        ref int nonMaxCount,
        ref int maxValueCount,
        uint[] nonMaxValues
    )
    {
        for (int i = 0; i < reversedArray.Length; i++)
        {
            if (reversedArray[i] == uint.MaxValue)
            {
                maxValueCount++;
            }
            else
            {
                nonMaxValues[nonMaxCount++] = reversedArray[i];
            }
        }
    }

    private static ulong ComputeHash(Span<uint> input)
    {
        ulong hash = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == uint.MaxValue)
            {
                break;
            }
            hash += input[i] * (ulong)i;
        }

        return hash;
    }
}
