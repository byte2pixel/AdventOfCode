using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day11;

internal class Day11Solver(int blinks = 25) : IDay11Solver
{
    private readonly int _blinks = blinks;

    private readonly Dictionary<ulong, ulong[]> _memoizationCache = [];

    /// <summary>
    /// Solve the problem getting the number of stones after the specified number of blinks
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public long Solve(ulong[] input)
    {
        Stopwatch sw = new();
        sw.Start();

        // Use a dictionary to track unique stone values and their counts
        Dictionary<ulong, long> stoneDistribution = [];

        // Initialize with input stones
        foreach (var stone in input)
        {
            stoneDistribution[stone] = stoneDistribution.GetValueOrDefault(stone, 0) + 1;
        }

        // Simulate blinks with efficient tracking
        for (int blink = 0; blink < _blinks; blink++)
        {
            Dictionary<ulong, long> newStoneDistribution = [];

            // Process each unique stone value
            foreach (var (stone, count) in stoneDistribution)
            {
                ulong[] transformedStones = TransformStone(stone);

                // Distribute the transformed stones
                foreach (var newStone in transformedStones)
                {
                    newStoneDistribution[newStone] =
                        newStoneDistribution.GetValueOrDefault(newStone, 0) + count;
                }
            }

            // Replace the stone distribution
            stoneDistribution = newStoneDistribution;
        }

        sw.Stop();
        // Calculate total stone count
        long totalStoneCount = stoneDistribution.Values.Sum();
        AnsiConsole.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");

        return totalStoneCount;
    }

    private ulong[] TransformStone(ulong input)
    {
        if (_memoizationCache.TryGetValue(input, out var cachedResult))
        {
            return cachedResult;
        }

        ulong[] result;
        if (input == 0)
            result = [1];
        else if (input == 1)
            result = [2024];
        else if (HasEvenDigitCount(input))
        {
            var (part1, part2) = SplitNumber(input);
            result = [part1, part2];
        }
        else
            result = [checked(input * 2024)];

        return result;
    }

    /// <summary>
    /// Split a number that has an even number of digits into two parts
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static (uint, uint) SplitNumber(ulong number)
    {
        string str = number.ToString();
        int mid = str.Length / 2;
        uint part1 = uint.Parse(str[..mid]);
        uint part2 = uint.Parse(str[mid..]);
        return (part1, part2);
    }

    /// <summary>
    /// Check if a number has an even number of digits
    /// </summary>
    /// <param name="number"></param>
    /// <returns>true if the number has an even number of digits</returns>
    private static bool HasEvenDigitCount(ulong number)
    {
        return number.ToString().Length % 2 == 0;
    }
}
