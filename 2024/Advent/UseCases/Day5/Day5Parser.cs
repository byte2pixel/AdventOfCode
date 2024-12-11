using System.Collections.ObjectModel;
using Spectre.Console;

namespace Advent.UseCases.Day5;

public class Day5Data()
{
    public required ReadOnlyDictionary<int, List<int>> PrintRules { get; init; }
    public required IEnumerable<IEnumerable<int>> PagesToPrint { get; init; }
}

public static class Day5Parser
{
    public static Day5Data Parse(string? input)
    {
        ArgumentNullException.ThrowIfNull(input);

        // split on double newlines giving the ordering rules and the pages to print
        var lines = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length != 2)
        {
            throw new ArgumentException(
                "Input must contain two sections separated by a double newline"
            );
        }

        // parse the ordering rules
        var rules = lines[0].Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var printRules = new Dictionary<int, List<int>>();
        foreach (var rule in rules)
        {
            var split = rule.Split("|");
            var key = int.Parse(split[0]);
            var value = int.Parse(split[1]);
            if (printRules.TryGetValue(key, out var values))
            {
                values.Add(value);
            }
            else
            {
                printRules[key] = [value];
            }
        }

        // parse the pages to print
        var pages = lines[1].Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var pagesToPrint = new List<List<int>>();
        foreach (var page in pages)
        {
            var pageNumbers = page.Split(",").Select(int.Parse).ToList();
            pagesToPrint.Add(pageNumbers);
        }

        return new Day5Data
        {
            PrintRules = new ReadOnlyDictionary<int, List<int>>(printRules),
            PagesToPrint = pagesToPrint
        };
    }
}
