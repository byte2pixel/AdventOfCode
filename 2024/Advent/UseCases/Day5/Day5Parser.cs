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
        ValidateInputSections(lines);

        // parse the ordering rules
        var printRules = ParsePrintRules(lines[0]);
        // parse the pages to print
        var pagesToPrint = ParsePagesToPrint(lines[1]);

        return new Day5Data
        {
            PrintRules = new ReadOnlyDictionary<int, List<int>>(printRules),
            PagesToPrint = pagesToPrint
        };
    }

    private static Dictionary<int, List<int>> ParsePrintRules(string rulesSection)
    {
        var printRules = new Dictionary<int, List<int>>(50);
        var rules = rulesSection.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var rule in rules)
        {
            var (key, value) = ParseRule(rule);
            AddRuleToDictionary(printRules, key, value);
        }

        return printRules;
    }

    private static (int key, int value) ParseRule(string rule)
    {
        var split = rule.Split("|");
        return (int.Parse(split[0].Trim()), int.Parse(split[1].Trim()));
    }

    private static void AddRuleToDictionary(
        Dictionary<int, List<int>> printRules,
        int key,
        int value
    )
    {
        if (printRules.TryGetValue(key, out var values))
        {
            values.Add(value);
        }
        else
        {
            printRules[key] = [value];
        }
    }

    private static List<List<int>> ParsePagesToPrint(string pagesSection)
    {
        var pages = pagesSection.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var pagesToPrint = new List<List<int>>(50);
        foreach (var page in pages)
        {
            var pageNumbers = page.Split(",").Select(int.Parse).ToList();
            pagesToPrint.Add(pageNumbers);
        }
        return pagesToPrint;
    }

    private static void ValidateInputSections(string[] lines)
    {
        if (lines.Length != 2)
        {
            throw new ArgumentException(
                "Input must contain two sections separated by a double newline",
                nameof(lines)
            );
        }
    }
}
