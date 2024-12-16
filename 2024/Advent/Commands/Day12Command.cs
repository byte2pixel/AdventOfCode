using Advent.Common;
using Advent.Common.Commands;
using Advent.Common.Settings;
using Advent.UseCases.Day12;
using Advent.UseCases.Day6;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Advent.Commands;

public class Day12Command(IFileReader reader, IAnsiConsole console)
    : AdventCommand<AdventSettings>(reader, console)
{
    public override async Task<int> ExecuteAsync(CommandContext context, AdventSettings settings)
    {
        var input = await _reader.ReadInputAsync("../input/day12input.txt");
        var data = Day6Parser.Parse(input);

        var choice = settings.Part ?? PromptForPartChoice();
        IDay6Solver solver = choice switch
        {
            "Part 1" => new Day12Part1Solver(),
            "Part 2" => new Day12Part2Solver(),
            _ => throw new InvalidOperationException("Invalid choice")
        };

        var result = solver.Solve(data);
        _console.MarkupLine($"[bold green]Day 12 {choice} [/]");
        _console.MarkupLine($"The answer is [bold yellow]{result}[/]");
        return 0;
    }
}
