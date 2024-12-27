using System.Collections.ObjectModel;
using System.Diagnostics;
using Spectre.Console;

namespace Advent.UseCases.Day5;

internal class Day5Part2Solver : IDay5Solver
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
        stopwatch.Stop(); // Averages 5.0 ms
        AnsiConsole.WriteLine($"Elapsed: {stopwatch.Elapsed.TotalMilliseconds} ms");
        return result;
    }

    private static int ProcessPagesAndRules(
        IEnumerable<int> pagesToProcess,
        ReadOnlyDictionary<int, List<int>> printRules
    )
    {
        int[] pages = pagesToProcess.ToArray();
        // for each page, iterate over the page numbers
        if (IsAlreadySorted(pages, printRules))
            return 0;

        int[] sortedPages = TopologicalSort(pages, printRules);

        return sortedPages[pages.Length / 2];
    }

    private static int[] TopologicalSort(int[] pages, ReadOnlyDictionary<int, List<int>> printRules)
    {
        var graph = new Dictionary<int, HashSet<int>>();
        var inDegree = new Dictionary<int, int>();

        IntializeGraphAndinDegree(pages, graph, inDegree);

        PopulateGraph(pages, printRules, graph, inDegree);

        var queue = new Queue<int>(pages.Where(p => inDegree[p] == 0));
        var result = new List<int>();

        ProcessQueue(graph, inDegree, queue, result);

        result.Reverse(); // Reverse to match advent expected order although it doesn't matter.
        return result.Count == pages.Length ? [.. result] : [.. pages];
    }

    private static void ProcessQueue(
        Dictionary<int, HashSet<int>> graph,
        Dictionary<int, int> inDegree,
        Queue<int> queue,
        List<int> result
    )
    {
        while (queue.Count > 0)
        {
            int currentPage = queue.Dequeue();
            result.Add(currentPage);

            foreach (int neighbor in graph[currentPage])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }
    }

    private static void PopulateGraph(
        int[] pages,
        ReadOnlyDictionary<int, List<int>> printRules,
        Dictionary<int, HashSet<int>> graph,
        Dictionary<int, int> inDegree
    )
    {
        // Build graph and calculate in-degrees
        foreach (int page in pages)
        {
            if (printRules.TryGetValue(page, out var rules))
            {
                foreach (int rule in rules)
                {
                    if (pages.Contains(rule) && graph[rule].Add(page))
                    {
                        inDegree[page]++;
                    }
                }
            }
        }
    }

    private static void IntializeGraphAndinDegree(
        int[] pages,
        Dictionary<int, HashSet<int>> graph,
        Dictionary<int, int> inDegree
    )
    {
        // Initialize graph for all pages
        foreach (int page in pages)
        {
            graph[page] = [];
            inDegree[page] = 0;
        }
    }

    private static bool IsAlreadySorted(
        Span<int> pages,
        ReadOnlyDictionary<int, List<int>> printRules
    )
    {
        for (int j = 0; j < pages.Length; j++)
        {
            // for each page number, iterate over the print rules
            HashSet<int> previousPages = pages[..j].ToArray().ToHashSet();
            if (
                printRules.TryGetValue(pages[j], out List<int>? rules)
                && rules.Any(previousPages.Contains)
            )
            {
                return false;
            }
        }
        return true;
    }
}
