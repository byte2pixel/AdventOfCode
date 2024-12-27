namespace Advent.UseCases.Day25;

internal static class Day25Parser
{
    internal static (List<GridData> locks, List<GridData> keys) Parse(string input)
    {
        var locksAndKeys = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        List<GridData> locks = [];
        List<GridData> keys = [];
        foreach (var lockOrKey in locksAndKeys)
        {
            var lines = lockOrKey.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            if (lines[0] == "#####")
            {
                locks.Add(new GridData(lines));
                continue;
            }
            else if (lines[0] == ".....")
            {
                // keys
                keys.Add(new GridData(lines));
                continue;
            }
            throw new InvalidOperationException("Invalid input");
        }
        return (locks, keys);
    }
}
