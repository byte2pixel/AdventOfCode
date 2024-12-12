using System.Collections.ObjectModel;
using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day5;

public class Day5Part1Solver : IDay5Solver
{
    public int Solve(Day5Data data)
    {
        int result = 0;
        Stopwatch stopwatch = new();
        stopwatch.Start();
        for (int i = 0; i < data.PagesToPrint.Count(); i++)
        {
            result += ProcessPagesAndRules(data.PagesToPrint.ElementAt(i), data.PrintRules);
        }
        stopwatch.Stop(); // Averages 1.6 ms
        AnsiConsole.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private static int ProcessPagesAndRules(
        IEnumerable<int> pagesToProcess,
        ReadOnlyDictionary<int, List<int>> printRules
    )
    {
        Span<int> pages = pagesToProcess.ToArray();
        // for each page, iterate over the page numbers
        for (int j = 0; j < pages.Length; j++)
        {
            // for each page number, iterate over the print rules
            HashSet<int> previousPages = pages[..j].ToArray().ToHashSet();
            if (printRules.TryGetValue(pages[j], out List<int>? rules))
            {
                if (Day5Helper.AlreadyFollowingRules(previousPages, rules))
                    continue;
                return 0;
            }
        }
        return pages[pages.Length / 2];
    }
}
