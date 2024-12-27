using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day25;

internal class Day25Part1Solver : IDay25Solver
{
    public string Solve((List<GridData> locks, List<GridData> keys) input)
    {
        Stopwatch sw = new();
        sw.Start();
        int uniqueKeyLockCombinations = FindAllUniqueKeyLockCombinations(input.locks, input.keys);
        sw.Stop();
        AnsiConsole.WriteLine($"Elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        return uniqueKeyLockCombinations.ToString();
    }

    private static int FindAllUniqueKeyLockCombinations(List<GridData> locks, List<GridData> keys)
    {
        int uniqueKeyLockCombinations = 0;

        keys.ForEach(key =>
        {
            locks.ForEach(theLock =>
            {
                if (CanUnlock(theLock, key))
                {
                    uniqueKeyLockCombinations++;
                }
            });
        });
        return uniqueKeyLockCombinations;
    }

    private static bool CanUnlock(GridData theLock, GridData key)
    {
        if (theLock.Rows != key.Rows || theLock.Columns != key.Columns)
        {
            return false;
        }
        for (int i = 0; i < theLock.Rows; i++)
        {
            var lockRow = theLock[i];
            var keyRow = key[i];
            for (int j = 0; j < theLock.Columns; j++)
            {
                if (lockRow[j] == '#' && keyRow[j] == '#')
                {
                    return false;
                }
            }
        }
        return true;
    }
}
