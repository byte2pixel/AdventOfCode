namespace Advent.UseCases.Day2;

internal static class Day2Helpers
{
    private static bool IsValidPair(int current, int next, bool isIncreasing)
    {
        if (current == next)
            return false;

        var diff = next - current;
        return isIncreasing ? (diff > 0 && diff <= 3) : (diff < 0 && diff >= -3);
    }

    internal static bool LineCheck(IEnumerable<int> newLine)
    {
        IEnumerable<(int First, int Second)> pairs = GetPairs(newLine);
        bool isIncreasing = GetDirection(pairs);
        return pairs.All(pair => IsValidPair(pair.First, pair.Second, isIncreasing));
    }

    internal static bool GetDirection(IEnumerable<(int First, int Second)> pairs)
    {
        var (First, Second) = pairs.First();
        var isIncreasing = First <= Second;
        return isIncreasing;
    }

    internal static IEnumerable<(int First, int Second)> GetPairs(IEnumerable<int> line)
    {
        return line.Zip(line.Skip(1));
    }
}
